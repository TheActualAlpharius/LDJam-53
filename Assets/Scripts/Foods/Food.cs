using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] foodSprites;
    [SerializeField] private static float DIGESTION_TIME = 4f;
    [SerializeField] public float digestionTime;
    [SerializeField] private GameObject childPrefab;
    public bool isDigesting = false;
    public bool notFood;
    private int numOfNutrients;
    private float goodNutrientChance;
    private int numOfPoop;
    public bool hasEnteredStomach = false;

    private Dictionary<string, float[]> nutrientInfo = new Dictionary<string, float[]>(){
        {"burger", new float[] {4f, 0.8f, 3f}},
        {"banana", new float[] {6f, 0.6f, 2f}},
        {"pizza", new float[] {4f, 0.7f, 4f}},
        {"boot", new float[] {3f, 0.03f, 2f}},
        {"cigar", new float[] {5f, 0.01f, 1f}},
        {"basketball", new float[] {4f, 0.05f, 2f}}
    };

    private void OnEnable(){
        transform.position = new Vector3(7.5f, 42f);
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        int randomIndex = Random.Range(0, foodSprites.Length);
        spriteRenderer.sprite = foodSprites[randomIndex];
        numOfNutrients = (int)nutrientInfo[spriteRenderer.sprite.name][0];
        goodNutrientChance = nutrientInfo[spriteRenderer.sprite.name][1];
        numOfPoop = (int) nutrientInfo[spriteRenderer.sprite.name][2];
        isDigesting = false;
        hasEnteredStomach = false;
        digestionTime = DIGESTION_TIME;



    }

    public void Update(){
        if(isDigesting){
            digestionTime -= Time.deltaTime;
            if(digestionTime <= 0){
                for(int i = 0; i < numOfPoop; i++){
                    GameObject child = ObjectPool.GetObject(childPrefab);
                    
                    child.transform.position = gameObject.transform.position + new Vector3(Random.Range(0.1f, 0.3f), Random.Range(0.1f, 0.3f), 0);
                    child.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
                    //set the nutrient info for the poop that is spawned after digestion
                    Poop poop = child.GetComponent<Poop>();
                    poop.goodNutrientChance = goodNutrientChance;
                    poop.numOfNutrients = numOfNutrients;
                }
                ObjectPool.ReleaseToPool(gameObject);
            }
        }
    }


}