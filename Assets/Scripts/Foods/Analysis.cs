using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analysis : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D other){
        Nutrient nutrient = other.gameObject.GetComponent<Nutrient>();
        if (nutrient != null)
        {
            nutrient.isAnalysing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        Nutrient nutrient = other.gameObject.GetComponent<Nutrient>();
        if (nutrient != null)
        {
            nutrient.isAnalysing = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Drag drag = collision.gameObject.GetComponent<Drag>();
        if (drag != null && drag.beingDragged)
        {
            return;
        }
        collision.attachedRigidbody.velocity = new Vector2(0f, 0f);
    }
}
