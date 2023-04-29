using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analysis : MonoBehaviour {


    private void OnTriggerStay2D(Collider2D other){
        Debug.Log("Collision!!");
        Nutrient nutrient = other.gameObject.GetComponent<Nutrient>();
        nutrient.isDissolving = true;
    }
}
