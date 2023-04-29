using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{

    private Rigidbody2D otherRigidbody;


    private void OnTriggerEnter2D(Collider2D other){
        otherRigidbody = other.gameObject.GetComponent<Rigidbody2D>();

        otherRigidbody.velocity = new Vector3(0, 20, 0);

    }

}
