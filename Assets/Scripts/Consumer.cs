using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    private void Start(){
        audioSource = GetComponent<AudioSource>();
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
            if(consumable.healthChange < 0){
                audioSource.Play();
            }
            HealthManager.ChangeHealth(consumable.healthChange);
            if (GameModeManager.GetMode().GetType().Name == "MainGameMode")
            {
                ScoreManager.ChangeScore(Mathf.RoundToInt(consumable.healthChange));
            }
            ObjectPool.ReleaseToPool(other.gameObject);
        }
    }
}
