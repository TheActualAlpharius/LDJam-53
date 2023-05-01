using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjectIfClicked : MonoBehaviour
{
    [SerializeField] GameObject objectToEnable;

    bool mouseDown;

    // Start is called before the first frame update
    void Start()
    {
        SetMouseDown(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseDown && !Input.GetMouseButton(0))
        {
            SetMouseDown(false);
        }
    }

    private void OnMouseExit()
    {
        SetMouseDown(false);
    }

    private void OnMouseDown()
    {
        SetMouseDown(true);
    }

    void SetMouseDown(bool _mouseDown)
    {
        mouseDown = _mouseDown;
        objectToEnable.SetActive(mouseDown);
    }
}
