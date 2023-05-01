using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakDownFood : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Food food = collision.gameObject.GetComponent<Food>();

        if (food != null)
        {
            food.isDigesting = true;
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
