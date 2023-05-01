using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nutrient : MonoBehaviour {
    public bool isGood;
    [SerializeField] public float analysisTime = 3f;
    [SerializeField] private GameObject badPrefab;
    [SerializeField] private GameObject goodPrefab;
    [SerializeField] private float healthChangeSize;
    public bool isAnalysing = false;

    private void Start()
    {
        float healthChange;
        if (isGood)
        {
            healthChange = healthChangeSize;
        }
        else
        {
            healthChange = -healthChangeSize;
        }
        GetComponent<Consumable>().healthChange = healthChange;

    }

    public void Update(){
        if(isAnalysing){
            analysisTime -= Time.deltaTime;
            if(analysisTime <= 0){ 
                GameObject child;
                if(isGood){
                    child = ObjectPool.GetObject(goodPrefab);
                } else {
                    child = ObjectPool.GetObject(badPrefab);
                }
                
                child.transform.position = gameObject.transform.position;
                ObjectPool.ReleaseToPool(gameObject);
            }
        }
    }
}
