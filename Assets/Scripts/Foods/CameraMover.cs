using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] List<Vector3> cameraPositions;
    [SerializeField] int startingIndex;
    [SerializeField] float propStepRate;

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

        transitionQueue = new List<CameraTransitionData>();
        currentIndex = startingIndex;
        transform.position = cameraPositions[startingIndex];
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    private void MoveTo(Vector3 _position)
    {
        Vector3 startPos;
        if (transitionQueue.Count > 0)
        {
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
        MoveTo(cameraPositions[startingIndex]);
    }
}
