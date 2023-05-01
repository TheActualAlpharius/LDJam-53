using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakDownFood : MonoBehaviour
{
    private AudioSource audioSource;
    private void Start(){
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Food food = collision.gameObject.GetComponent<Food>();

        if (food != null)
        {
            food.isDigesting = true;
            audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Food food = collision.gameObject.GetComponent<Food>();

        if (food != null)
        {
            food.isDigesting = false;
        }
    }
}
