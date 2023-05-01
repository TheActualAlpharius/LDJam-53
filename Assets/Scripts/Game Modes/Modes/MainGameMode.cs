using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameMode : BaseMode
{
    private static float healthLossRate = 0.1f;

    private CameraMover cameraMover;

    public MainGameMode()
    {
        cameraMover = GameObject.FindObjectOfType<CameraMover>();
    }

    public override void TransitionIn()
    {
        cameraMover.ResetCamera();

        HealthManager.ResetHealth();
    }

    public override void TransitionOut()
    {
        HealthManager.SetHealth(0f);
    }

    public override void Update()
    {
        // Drain health
        HealthManager.ChangeHealth(-healthLossRate * Time.deltaTime);
    }

    public override void FixedUpdate()
    {

    }
}
