using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : Singleton<HealthManager>
{
    [SerializeField] float startingHealth;

    private float health;

    public override void InitSingleton()
    {
        health = startingHealth;
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
        instance.health = instance.startingHealth;
    }

    public static float GetHealth()
    {
        return instance.health;
    }
}
