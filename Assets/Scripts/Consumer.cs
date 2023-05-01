using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Consumable consumable = other.gameObject.GetComponent<Consumable>();

        if (consumable)
        {
            HealthManager.ChangeHealth(consumable.healthChange);
            ObjectPool.ReleaseToPool(other.gameObject);
        }
    }
}
