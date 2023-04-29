using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analysis : MonoBehaviour {


    private void OnTriggerStay2D(Collider2D other){
        Debug.Log("Collision!!");
        Nutrient nutrient = other.gameObject.GetComponent<Nutrient>();
        if(nutrient == null) return;
        nutrient.analysisTime -= Time.deltaTime;
        if(nutrient.analysisTime >= 0) return;
        //destroy that shit
        Debug.Log("timor");
    }
}
