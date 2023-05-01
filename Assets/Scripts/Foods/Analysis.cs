using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analysis : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D other){
        Nutrient nutrient = other.gameObject.GetComponent<Nutrient>();
        nutrient.isAnalysing = true;
    }

    private void OnTriggerExit2D(Collider2D other){
        Nutrient nutrient = other.gameObject.GetComponent<Nutrient>();
        nutrient.isAnalysing = false;
    }
}
