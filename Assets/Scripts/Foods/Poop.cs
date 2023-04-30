using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour {

    [SerializeField] private List<GameObject> childPrefabs;
    [SerializeField] public float health;

    public void emmitNutirent(){
        
        GameObject child = ObjectPool.GetObject(childPrefabs[0]);
        childPrefabs.RemoveAt(0);
        Nutrient nut = child.GetComponent<Nutrient>();
        nut.isGood = Random.value > health;
        if(childPrefabs.Count == 0){
            ObjectPool.ReleaseToPool(gameObject);
        }
        
    }
}
