using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nutrient : MonoBehaviour {
    public bool isGood;
    [SerializeField] public float analysisTime = 3f;
    [SerializeField] private GameObject childPrefab;
    public bool isDissolving = false;

    public void Update(){
        if(isDissolving){
            analysisTime -= Time.deltaTime;
            if(analysisTime <= 0){ 
            //destroy that shit
            Debug.Log("Destructo");
            GameObject child = ObjectPool.GetObject(childPrefab);
            child.transform.position = gameObject.transform.position;
            ObjectPool.ReleaseToPool(gameObject);
            }
        }
    }
}
