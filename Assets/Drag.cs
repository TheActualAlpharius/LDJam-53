using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{

    private Vector3 offset = Vector3.zero;
    private Vector3 lastPosition = Vector3.zero;
    private Camera _cam;
    private Vector3 trailingDir = Vector3.zero; //direction obj is travelling OnMouseUp
    [SerializeField] private float _speed = 50; //speed at which obj follows mouse
    [SerializeField] private float friction = 0.01f; //how much sliding happens when mouse is released
    private Vector3 rigidBodyVelocity;
    private Rigidbody2D rigidbody;
    private void Awake(){
        _cam = Camera.main;
        rigidbody = GetComponent<Rigidbody2D>();

    }

    private void OnMouseDown(){
        trailingDir = Vector3.zero;
        offset = _cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    private void OnMouseDrag(){
        lastPosition = rigidbody.position;
        //rigidbody.position = Vector3.MoveTowards(rigidbody.position, _cam.ScreenToWorldPoint(Input.mousePosition) - difference, _speed * Time.deltaTime);
        Debug.Log((Vector3)rigidbody.position);    
        rigidbody.velocity = (_cam.ScreenToWorldPoint(Input.mousePosition) - (Vector3)rigidbody.position - offset) * _speed;
    }

    private void OnMouseUp(){
        rigidbody.velocity = transform.position - lastPosition;

    }

    private void FixedUpdate(){
        if (rigidbody.velocity.magnitude > 0){
            //rigidbody.velocity -= rigidbody.velocity * friction;
        }

    }

}
