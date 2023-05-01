using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] List<Vector3> cameraPositions;
    [SerializeField] int startingIndex;
    [SerializeField] float propStepRate;
    [SerializeField] float floatDir;
    [SerializeField] float floatSpeed;
    [SerializeField] float maxFloatY;
    [SerializeField] float minFloatY;
    [SerializeField] float shakeStrength;
    [SerializeField] float maxShakeDistance;
    [SerializeField] bool shakeEnabled;
    public AudioSource audioSourceClick;
    private Vector3 lastShakeOffset;

    struct CameraTransitionData
    {
        public Vector3 startPos;
        public Vector3 endPos;

        public CameraTransitionData(Vector3 _startPos, Vector3 _endPos)
        {
            startPos = _startPos;
            endPos = _endPos;
        }
    }

    private List<CameraTransitionData> transitionQueue;
    private float propThrough;
    private int currentIndex;

    private Vector3 previousPos;

    // Start is called before the first frame update
    void Start()
    {
        propThrough = 0f;
        lastShakeOffset = new Vector3(0f, 0f, 0f);

        transitionQueue = new List<CameraTransitionData>();
        currentIndex = startingIndex;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= lastShakeOffset;
        if (transitionQueue.Count > 0)
        {
            propThrough = Mathf.Min(1f, propThrough + propStepRate * Time.deltaTime);

            CameraTransitionData transition = transitionQueue[0];

            transform.position = transition.startPos + ScaledPropThrough(propThrough) * (transition.endPos - transition.startPos);

            if (propThrough >= 1f)
            {
                transitionQueue.RemoveAt(0);
                propThrough = 0f;
            }
        }
        transform.position = transform.position + new Vector3(0f, floatDir * floatSpeed * Time.deltaTime, 0f);
        if (transform.position.y > maxFloatY)
        {
            transform.position = new Vector3(transform.position.x, maxFloatY, transform.position.z);
            floatDir *= -1;
        }
        else if (transform.position.y < minFloatY)
        {
            transform.position = new Vector3(transform.position.x, minFloatY, transform.position.z);
            floatDir *= -1;
        }
        if (shakeEnabled)
        {
            Vector3 shakeOffset = new Vector3(0f, Random.Range(-1f, 1f), 0f) * maxShakeDistance * shakeStrength;
            transform.position += shakeOffset;
            lastShakeOffset = shakeOffset;
        }
        else
        {
            lastShakeOffset = new Vector3(0f, 0f, 0f);
        }
    }

    private void MoveTo(Vector3 _position)
    {
        Vector3 startPos;
        if (transitionQueue.Count > 0)
        {
            audioSourceClick.Play();
            startPos = transitionQueue[transitionQueue.Count - 1].endPos;
        }
        else
        {
            startPos = transform.position;
        }

        if (startPos != _position)
        {
            transitionQueue.Add(new CameraTransitionData(startPos, _position));
        }
    }

    public void ChangeCameraIndex(int _change)
    {
        currentIndex = Mathf.Clamp(currentIndex + _change, 0, cameraPositions.Count - 1);
        MoveTo(cameraPositions[currentIndex]);
    }

    private float ScaledPropThrough(float _prop)
    {
        return 0.5f * (Mathf.Sin(Mathf.PI * (_prop - 0.5f)) + 1f);
    }

    public void ResetCamera()
    {
        ChangeCameraIndex(startingIndex - currentIndex);
    }

    public void StopFloating()
    {
        floatDir = 0f;
    }

    public void SetShakeStrength(float _shakeStrength)
    {
        shakeStrength = _shakeStrength;
    }

    public void SetShakeEnabled(bool _shakeEnabled)
    {
        shakeEnabled = _shakeEnabled;
    }

    public void StartFloating()
    {
        float heightProp = (transform.position.y - minFloatY) / (maxFloatY - minFloatY);
        if (heightProp < 0.5)
        {
            floatDir = 1f;
        }
        else
        {
            floatDir = -1f;
        }
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }
}
