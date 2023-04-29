using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{

    private Vector3 offset = Vector3.zero;
    private Camera _cam;
    [SerializeField] private float _speed = 50; //speed at which obj follows mouse
    [SerializeField] private float maxSpeed = 10f;
    private Rigidbody2D rigidbody;
    private void Awake(){
        _cam = Camera.main;
        rigidbody = GetComponent<Rigidbody2D>();

    }

    private void OnMouseDown(){
        offset = _cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    private void OnMouseDrag(){
        //rigidbody.position = Vector3.MoveTowards(rigidbody.position, _cam.ScreenToWorldPoint(Input.mousePosition) - difference, _speed * Time.deltaTime);
        rigidbody.velocity = (_cam.ScreenToWorldPoint(Input.mousePosition) - (Vector3)rigidbody.position - offset) * _speed;
        float magnitude = rigidbody.velocity.magnitude;
        rigidbody.velocity = rigidbody.velocity * Mathf.Min(magnitude, maxSpeed) / magnitude;
        

    }


}
