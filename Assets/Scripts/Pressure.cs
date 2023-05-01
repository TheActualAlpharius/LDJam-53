using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure : MonoBehaviour
{
    [SerializeField] int maxObjects;
    [SerializeField] int currentObjects;

    private CameraMover cameraMover;

    private void Start()
    {
        cameraMover = FindObjectOfType<CameraMover>();

        GameModeManager.AddModeChangeListener((BaseMode _newMode) => currentObjects = 0);
    }

    public float GetPressure()
    {
        return (float)currentObjects/(float)maxObjects;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Poop>())
        {
            currentObjects++;

            if (GetPressure() > 1f)
            {
                GameModeManager.SetMode("ScoreMode");
            }

            cameraMover.SetShakeStrength(ScalePressure(GetPressure()));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Poop>())
        {
            currentObjects--;
            cameraMover.SetShakeStrength(ScalePressure(GetPressure()));
        }
    }

    private float ScalePressure(float _pressure)
    {
        return Mathf.Max(0f, _pressure - 0.5f) * 2f;
    }
}
