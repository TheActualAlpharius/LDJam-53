using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(HealthManager.GetHealth().ToString());
        healthText.text = "Health: " + HealthManager.GetHealth().ToString();
    }
}
