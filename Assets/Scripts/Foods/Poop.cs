using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour {

    [SerializeField] private List<GameObject> childPrefabs;
    [SerializeField] public float health;
    public int numOfNutrients;
    public float goodNutrientChance;
    bool flag = true;

    private void OnEnable(){
    }
    public void emitNutirent(){
        
        GameObject child = ObjectPool.GetObject(childPrefabs[0]);
        childPrefabs.RemoveAt(0);
        Nutrient nut = child.GetComponent<Nutrient>();
        nut.isGood = Random.value > health;
        if(childPrefabs.Count == 0){
            ObjectPool.ReleaseToPool(gameObject);
        }
        
    }

    private void Update(){
        if (transform.position.y > 15){
            ObjectPool.ReleaseToPool(gameObject);
            //add or subtract score depending on whether good or bad food
        }
    }
}
