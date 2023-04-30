using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObjectsOnExit : MonoBehaviour
{
    
    private Rigidbody2D otherRigidbody;
    private void OnTriggerExit2D(Collider2D other){
        otherRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
        ObjectPool.ReleaseToPool(other.gameObject);
    }    
}
