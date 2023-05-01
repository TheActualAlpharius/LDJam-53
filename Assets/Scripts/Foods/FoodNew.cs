using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodNew : MonoBehaviour
{
    private SpriteRenderer[] spriteRenderers;
    private Collider2D[] colliders;
    // Start is called before the first frame update
    private void Start(){
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        
        colliders = GetComponentsInChildren<Collider2D>();

        Debug.Log(spriteRenderers.Length);
        Debug.Log(colliders.Length);

    }
}
