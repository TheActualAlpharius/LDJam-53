using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnFood : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;
    private void Start(){
        ObjectPool.GetObject(foodPrefab);
    }
}
