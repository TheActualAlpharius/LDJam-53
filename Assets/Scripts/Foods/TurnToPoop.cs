using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToPoop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        Food foodItem = other.gameObject.GetComponent<Food>();
        if(foodItem != null){
            foodItem.isDigesting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){

        Food foodItem = other.gameObject.GetComponent<Food>();
        if(foodItem != null){
            foodItem.isDigesting = false;
        }
    }

}
