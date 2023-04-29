using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    [SerializeField] private string poolID;


    public string GetPoolID()
    {
        return poolID;
    }


    void OnDestroy()
    {
        if (ObjectPool.instance)
        {
            ObjectPool.RemoveFromPool(this.gameObject);
        }
    }
}
