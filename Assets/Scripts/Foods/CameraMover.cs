using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] float propStepRate;
    [SerializeField] Vector3 targetPos;
    [SerializeField] float propThrough;

    private Vector3 previousPos;

    // Start is called before the first frame update
    void Start()
    {
        propThrough = 1f;

        MoveTo(new Vector3(0f, 35f, -10f));
    }

    // Update is called once per frame
    void Update()
    {
        if (propThrough < 1f)
        {
            propThrough = Mathf.Min(1f, propThrough + propStepRate * Time.deltaTime);

            transform.position = previousPos + ScaledPropThrough(propThrough) * (targetPos - previousPos);
        }
    }

    public void MoveTo(Vector3 _position)
    {
        previousPos = transform.position;
        targetPos = _position;
        propThrough = 0f;
    }

    private float ScaledPropThrough(float _prop)
    {
        return 0.5f * (Mathf.Sin(Mathf.PI * (_prop - 0.5f)) + 1f);
    }
}
