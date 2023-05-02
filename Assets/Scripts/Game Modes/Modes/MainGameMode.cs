using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameMode : BaseMode
{
    private static float minHealthLossRate = 0.07f;
    private static float maxHealthLossRate = 0.14f;
    private static float timeToMaxHealthLossRate = 120f;
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

        Food.guaranteeFood = true;
        HealthManager.ResetHealth();
        ScoreManager.ResetScore();
        cameraMover.SetShakeEnabled(true);
    }

    public override void TransitionOut()
    {
        HealthManager.SetHealth(0f);
        cameraMover.SetShakeEnabled(false);
    }

    public override void Update()
    {
        // Drain health
        HealthManager.ChangeHealth(-GetCurrentHealthLossRate() * Time.deltaTime);
        ScoreManager.SetScore(Mathf.FloorToInt(Time.time - startTime));
    }

    public override void FixedUpdate()
    {

    }

    float GetCurrentHealthLossRate()
    {
        float propThrough = Mathf.Clamp((Time.time - startTime) / timeToMaxHealthLossRate, 0f, 1f);

        return minHealthLossRate + propThrough * (maxHealthLossRate - minHealthLossRate);
    }
}
