using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameMode : BaseMode
{
    private static float healthLossRate = 0.07f;
    private float startTime;

    private CameraMover cameraMover;

    public MainGameMode()
    {
        cameraMover = GameObject.FindObjectOfType<CameraMover>();
    }

    public override void TransitionIn()
    {
        startTime = Time.time;

        cameraMover.ResetCamera();

        HealthManager.ResetHealth();
        ScoreManager.ResetScore();
    }

    public override void TransitionOut()
    {
        HealthManager.SetHealth(0f);
    }

    public override void Update()
    {
        // Drain health
        HealthManager.ChangeHealth(-healthLossRate * Time.deltaTime);
        ScoreManager.SetScore(Mathf.FloorToInt(Time.time - startTime));
    }

    public override void FixedUpdate()
    {

    }
}
