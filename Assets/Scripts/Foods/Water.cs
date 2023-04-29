using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private float waterDrag = 10f;
    private Rigidbody2D otherRigidbody;

    private void OnTriggerStay2D(Collider2D other){

        FloatOnWater floatOnWater = other.gameObject.GetComponent<FloatOnWater>();
        Rigidbody2D otherRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
        otherRigidbody.drag = waterDrag;

        if (floatOnWater != null){
            //otherRigidbody.AddForce()
        }
    }

    private void OnTriggerExit(){
        
    }

}
