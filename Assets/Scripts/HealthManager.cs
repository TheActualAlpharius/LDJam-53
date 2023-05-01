using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : Singleton<HealthManager>
{
    [SerializeField] float maxHealth;

    private float health;

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
        instance.health += _diff;
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
