using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : Singleton<GameModeManager>
{
    [SerializeField] string initialMode;

    private BaseMode currentMode;

    private System.Action<BaseMode> onModeChanged;

    private static Dictionary<string, BaseMode> modes;


    public override void InitSingleton()
    {
        modes = new Dictionary<string, BaseMode>();
        modes.Add("MenuMode", new MenuMode());
        modes.Add("MainGameMode", new MainGameMode());

        onModeChanged = null;

        SetMode(initialMode);
    }

    private void Start()
    {
        if (instance != this)
        {
            return;
        }
    }

    void Update()
    {
        if (instance != this)
        {
            return;
        }
        instance.currentMode.Update();
    }

    void FixedUpdate()
    {
        if (instance != this)
        {
            return;
        }
        instance.currentMode.FixedUpdate();
    }

    public static void SetMode(string _modeName)
    {
        BaseMode newMode = modes[_modeName];
        if (instance.currentMode == null || instance.currentMode.GetType() != newMode.GetType())
        {
            //Debug.Log("Transitioning to game mode: " + _modeName);

            instance.currentMode?.TransitionOut();
            newMode?.TransitionIn();
            instance.currentMode = newMode;

            if (instance.onModeChanged != null)
            {
                instance.onModeChanged(newMode);
            }
        }
    }

    public void SetModeInstance(string _modeName)
    {  
        SetMode(_modeName);
    }

    public static BaseMode GetMode()
    {
        if (instance != null)
        {
            return instance.currentMode;
        }
        return null;
    }

    public static void AddModeChangeListener(System.Action<BaseMode> _action)
    {
        if (instance != null)
        {
            instance.onModeChanged += _action;
        }
    }

    public static void RemoveModeChangeListened(System.Action<BaseMode> _action)
    {
        if (instance != null)
        {
            instance.onModeChanged -= _action;
        }
    }
}
