using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
    [SerializeField] public float digestionTime = 60*5f;
    [SerializeField] private List<GameObject> childPrefabs;
    public bool isDigesting = false;

    public void Update(){
        if(isDigesting){
            digestionTime -= Time.deltaTime;
            if(digestionTime <= 0){
                foreach (var childPrefab in childPrefabs){
                    GameObject child = ObjectPool.GetObject(childPrefab);
                    child.transform.position = gameObject.transform.position;
                }
                ObjectPool.ReleaseToPool(gameObject);
            }
        }
    }

}
