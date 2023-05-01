using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] int score;

    public override void InitSingleton()
    {
        score = 0;
    }

    public static void SetScore(int _score)
    {
        instance.score = _score;
    }

    public static void ChangeScore(int _diff)
    {
        instance.score = Mathf.Max(0, instance.score + _diff);
    }

    public static void ResetScore()
    {
        instance.score = 0;
    }

    public static float GetScore()
    {
        return instance.score;
    }
}
