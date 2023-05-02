using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUpChute : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSourceVomit;
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other){
        Rigidbody2D otherRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
        Food food = other.gameObject.GetComponent<Food>();
        if (food != null){
            if (food.hasEnteredStomach){
                audioSourceVomit.Play();
                //shoot the food up
                otherRigidbody.velocity = new Vector3(otherRigidbody.velocity.x, 30f);
                //otherRigidbody.AddForce(new Vector3(0, 30f));

            }
        }else{
            //shoot the poop up
            otherRigidbody.velocity = new Vector3(otherRigidbody.velocity.x, 30f);
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D otherRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
        Food food = other.gameObject.GetComponent<Food>();
        if (food != null)
        {
            if (food.hasEnteredStomach)
            {
                //shoot the food up
                otherRigidbody.velocity = new Vector3(otherRigidbody.velocity.x, 30f);
                //otherRigidbody.AddForce(new Vector3(0, 30f));

            }
        }else{
            otherRigidbody.velocity = new Vector3(otherRigidbody.velocity.x, 30f);
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        Food food = other.gameObject.GetComponent<Food>();
        if (food != null){
            if (food.transform.position.y > 30){
                ObjectPool.ReleaseToPool(other.gameObject);
            }
            if (!food.hasEnteredStomach)
            {
                food.hasEnteredStomach = true;
            }
        }
    }
}
