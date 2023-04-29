using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    // If you want an object to be pooled, add a PooledObject script to it and give it some sensible ID
    // Then always call ObjectPool.GetObject(the prefab you want to instantiate) instead of Instantiate
    // And always call ObjectPool.ReleaseToPool(the instantiated obejct) instead of Destroy
    // Add any logic you'd put in Start() to OnEnable() instead, since Start won't be called when we take it out the pool but OnEnable will be

    private Dictionary<string, List<GameObject>> objectPools;


    public override void InitSingleton()
    {
        objectPools = new Dictionary<string, List<GameObject>>();
    }


    private static List<GameObject> GetPoolForObject(GameObject _object)
    {
        PooledObject pooledObject = _object.GetComponent<PooledObject>();
        if (!pooledObject)
        {
            Debug.LogError("ObjectPool.GetPoolForObject called on GameObject " + _object.name + " with no PooledObject script");
            return null;
        }
        string poolID = pooledObject.GetPoolID();

        // Get the pool for the requested object, or create an empty pool if it does not exist.
        List<GameObject> requestedPool;
        if (!instance.objectPools.ContainsKey(poolID))
        {
            requestedPool = new List<GameObject>();
            instance.objectPools[poolID] = requestedPool;
        }
        else
        {
            requestedPool = instance.objectPools[poolID];
        }
        return requestedPool;
    }


    public static GameObject GetObject(GameObject _prefab)
    {
        List<GameObject> requestedPool = GetPoolForObject(_prefab);

        // Retrieve an object from the pool, or create a new one if none are available.
        GameObject requestedObject;
        if (requestedPool != null && requestedPool.Count > 0)
        {
            requestedObject = requestedPool[0];
            requestedObject.SetActive(true);
            requestedPool.RemoveAt(0);
        }
        else
        {
            requestedObject = Instantiate(_prefab);
        }
        return requestedObject;
    }


    public static void ReleaseToPool(GameObject _object)
    {
        AddToPool(_object);
        _object.SetActive(false);
    }


    public static void AddToPool(GameObject _object)
    {
        List<GameObject> affectedPool = GetPoolForObject(_object);
        affectedPool.Add(_object);
    }


    public static void RemoveFromPool(GameObject _object)
    {
        List<GameObject> affectedPool = GetPoolForObject(_object);
        affectedPool.Remove(_object);
    }
}
