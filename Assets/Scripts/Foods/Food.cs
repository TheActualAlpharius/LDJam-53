using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] foodSprites;
    [SerializeField] private static float DIGESTION_TIME = 2f;
    [SerializeField] public float digestionTime;
    [SerializeField] private List<GameObject> childPrefabs;
    public bool isDigesting = false;
    public bool notFood;
    private int numOfNutrients;
    private float goodNutrientChance;
    public bool hasEnteredStomach = false;

    private Dictionary<string, float[]> nutrientInfo = new Dictionary<string, float[]>(){
        {"burger", new float[] {4f, 0.8f}},
        {"banana", new float[] {6f, 0.5f}},
        {"pizza", new float[] {4f, 0.8f}},
        {"boot", new float[] {3f, 0.1f}},
        {"cigar", new float[] {5f, 0.01f}},
        {"basketball", new float[] {4f, 0.05f}}
    };

    private void OnEnable(){
        transform.position = new Vector3(7.5f, 38f);
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Debug.Log(spriteRenderer.sprite);
        int randomIndex = Random.Range(0, foodSprites.Length);
        spriteRenderer.sprite = foodSprites[randomIndex];
        numOfNutrients = (int)nutrientInfo[spriteRenderer.sprite.name][0];
        goodNutrientChance = nutrientInfo[spriteRenderer.sprite.name][1];
        isDigesting = false;
        hasEnteredStomach = false;
        digestionTime = DIGESTION_TIME;



    }

    public void Update(){
        if(isDigesting){
            Debug.Log(digestionTime);
            digestionTime -= Time.deltaTime;
            if(digestionTime <= 0){
                Debug.Log("Digesting");
                foreach (var childPrefab in childPrefabs){
                    GameObject child = ObjectPool.GetObject(childPrefab);
                    
                    child.transform.position = gameObject.transform.position;
                    child.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
                    //set the nutrient info for the poop that is spawned after digestion
                    Poop poop = child.GetComponent<Poop>();
                    poop.goodNutrientChance = goodNutrientChance;
                    poop.numOfNutrients = numOfNutrients;
                }
                ObjectPool.ReleaseToPool(gameObject);
            }
        }
        if (hasEnteredStomach == true & transform.position.y > 35){
            ObjectPool.ReleaseToPool(gameObject);
            //add or subtract score depending on whether good or bad food
        }
    }


}