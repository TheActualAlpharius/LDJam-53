using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private float waterDrag = 10f;
    private Rigidbody2D otherRigidbody;
    private float ogDrag;

    private void OnTriggerEnter2D(Collider2D other){

        FloatOnWater floatOnWater = other.gameObject.GetComponent<FloatOnWater>();
        otherRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
        Food foodItem = other.gameObject.GetComponent<Food>();
        Debug.Log(foodItem != null);
        if(foodItem != null){
            foodItem.isDigesting = true;
        }
            
        if (floatOnWater != null){
            ogDrag = otherRigidbody.drag;
            otherRigidbody.drag = waterDrag;
            //otherRigidbody.AddForce()
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        otherRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
        otherRigidbody.drag = ogDrag;

        Food foodItem = other.gameObject.GetComponent<Food>();
        if(foodItem != null){
            foodItem.isDigesting = false;
        }
    }

}
