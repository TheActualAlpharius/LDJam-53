using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] float maxWidth;
    [SerializeField] float minWidth;

    private Image healthBarLine;

    // Start is called before the first frame update
    void Start()
    {
        healthBarLine = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float newWidth = minWidth + (maxWidth - minWidth) * HealthManager.GetHealth() / HealthManager.GetMaxHealth();
        healthBarLine.rectTransform.sizeDelta = new Vector2(newWidth, healthBarLine.rectTransform.sizeDelta.y);
    }
}
