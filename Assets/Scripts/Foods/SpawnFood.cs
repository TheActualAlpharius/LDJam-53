using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnFood : MonoBehaviour
{
    private float timeSinceLastSpawn = 0;
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private float maxSpawnTime;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float roundTimeForMinSpawnTime;

    private float startTime; //time when spawning began
    private void OnEnable(){
        startTime = Time.time;

        timeSinceLastSpawn = maxSpawnTime;

    }

    private void Update(){
        if (timeSinceLastSpawn > GetCurrentSpawnTime()){
            ObjectPool.GetObject(foodPrefab);
            timeSinceLastSpawn = 0;
        }
        timeSinceLastSpawn += Time.deltaTime;
    }

    float GetCurrentSpawnTime()
    {
        float propThrough = Mathf.Clamp((Time.time - startTime)/roundTimeForMinSpawnTime, 0f, 1f);

        return maxSpawnTime + propThrough * (minSpawnTime - maxSpawnTime);
    }
}
