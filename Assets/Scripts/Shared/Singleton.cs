using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T lazyInstance;
    public static T instance
    {
        get
        {
            if (!lazyInstance)
            {
                lazyInstance = FindObjectOfType<T>()?.GetComponent<T>();

                if (!lazyInstance)
                {
                    Debug.LogError("Singleton " + typeof(T).Name + " accessed but no instance found.");
                }
                else
                {
                    lazyInstance.InitSingleton();
                }
            }
            return lazyInstance;
        }
    }

    public virtual void InitSingleton()
    {

    }
}
