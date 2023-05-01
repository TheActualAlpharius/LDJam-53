using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressureBar : MonoBehaviour
{
    [SerializeField] float maxWidth;
    [SerializeField] float minWidth;

    private Pressure pressure;
    private Image pressureBarLine;

    // Start is called before the first frame update
    void Start()
    {
        pressure = FindObjectOfType<Pressure>();
        pressureBarLine = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float newWidth = minWidth + (maxWidth - minWidth) * pressure.GetPressure();
        pressureBarLine.rectTransform.sizeDelta = new Vector2(newWidth, pressureBarLine.rectTransform.sizeDelta.y);
    }
}
