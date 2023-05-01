using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : Singleton<HealthManager>
{
    [SerializeField] float maxHealth;

    [SerializeField] float health;

    public override void InitSingleton()
    {
        health = maxHealth;
    }

    public static void SetHealth(float _health)
    {
        instance.health = _health;
    }

    public static void ChangeHealth(float _diff)
    {
        instance.health = Mathf.Max(0f, instance.health + _diff);
        if (instance.health <= 0f)
        {
            GameModeManager.SetMode("ScoreMode");
        }
    }

    public static void ResetHealth()
    {
        instance.health = instance.maxHealth;
    }

    public static float GetHealth()
    {
        return instance.health;
    }

    public static float GetMaxHealth()
    {
        return instance.maxHealth;
    }
}
