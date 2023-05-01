using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnFood : MonoBehaviour
{
    private float totalTime = 0;
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private float spawnTime = 5f;
    private void Start(){
        ObjectPool.GetObject(foodPrefab);

    }

    private void Update(){
        if (totalTime > spawnTime){
            ObjectPool.GetObject(foodPrefab);
            totalTime = 0;
        }
        totalTime += Time.deltaTime;
    }
}
