using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] foodSprites;
    [SerializeField] private Sprite[] nonFoodSprites;
    public bool notFood;
    private void OnEnable(){
        transform.position = new Vector3(7.5f, 38f);
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Debug.Log(spriteRenderer.sprite);
        int randomIndex = Random.Range(0, foodSprites.Length + nonFoodSprites.Length);
        if (randomIndex < foodSprites.Length){
            notFood = false;
            spriteRenderer.sprite = foodSprites[randomIndex];
        }else{
            notFood = true;
            spriteRenderer.sprite = nonFoodSprites[randomIndex % foodSprites.Length];
        }
        


    }

}