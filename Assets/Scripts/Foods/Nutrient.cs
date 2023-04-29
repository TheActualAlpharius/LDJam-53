using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nutrient : MonoBehaviour {
    public bool isGood;
    [SerializeField] public float analysisTime = 3f;
    public bool isDissolving = false;
    public Nutrient(bool good){
        isGood = good;
    }

    public void Update(){
        if(isDissolving){
            analysisTime -= Time.deltaTime;
            if(analysisTime <= 0){ 
            //destroy that shit
            Debug.Log("timor");
            }
        }
    }
}
