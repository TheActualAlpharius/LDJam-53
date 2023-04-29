using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour {

    [SerializeField] private List<GameObject> childPrefabs;
    [SerializeField] public float health;

    public void emmitNutirent(){

        GameObject child = ObjectPool.GetObject(childPrefabs.RemoveAt(0));
        child.Nutrient.health = health;
        if(childPrefabs.Count == 0){
            ObjectPool.ReleaseToPool(gameObject);
        }
        
    }
}
