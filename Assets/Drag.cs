using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{

    private Vector3 difference = Vector3.zero;
    private Vector3 lastPosition = Vector3.zero;
    private Camera _cam;
    private Vector3 trailingDir = Vector3.zero;
    [SerializeField] private float _speed = 50;
    [SerializeField] private float friction = 0.01f;

    private void Awake(){
        _cam = Camera.main;
    }

    private void OnMouseDown(){
        trailingDir = Vector3.zero;
        difference = _cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    private void OnMouseDrag(){
        Debug.Log(transform.position == lastPosition);
        lastPosition = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, _cam.ScreenToWorldPoint(Input.mousePosition) - difference, _speed * Time.deltaTime);
    }

    private void OnMouseUp(){
        trailingDir = transform.position - lastPosition;

    }

    private void Update(){
        Debug.Log(trailingDir);
        if (trailingDir.magnitude > 0){
            transform.position += trailingDir;
            trailingDir -= trailingDir * friction;
        }

    }

}
