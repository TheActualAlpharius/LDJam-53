using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public bool beingDragged;

    private Vector3 offset = Vector3.zero;
    private Camera _cam;
    [SerializeField] private float _speed = 50; //speed at which obj follows mouse
    [SerializeField] private float maxSpeed = 10f;
    private Rigidbody2D rigidBody;
    private void Awake(){
        _cam = Camera.main;
        rigidBody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (beingDragged && !Input.GetMouseButton(0))
        {
            beingDragged = false;
        }
    }

    private void OnMouseDown(){
        offset = _cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        beingDragged = true;
    }

    private void OnMouseDrag(){
        //rigidBody.position = Vector3.MoveTowards(rigidBody.position, _cam.ScreenToWorldPoint(Input.mousePosition) - difference, _speed * Time.deltaTime);
        rigidBody.velocity = (_cam.ScreenToWorldPoint(Input.mousePosition) - (Vector3)rigidBody.position - offset) * _speed;
        float magnitude = rigidBody.velocity.magnitude;
        if (magnitude == 0) return;
        rigidBody.velocity = rigidBody.velocity * Mathf.Min(magnitude, maxSpeed) / magnitude;
    }



}
