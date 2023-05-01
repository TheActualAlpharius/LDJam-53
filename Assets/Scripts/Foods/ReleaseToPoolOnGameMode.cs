using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseToPoolOnGameMode : MonoBehaviour
{
        [SerializeField] string mode;

    // Start is called before the first frame update
    void Start()
    {
        GameModeManager.AddModeChangeListener(OnModeChanged);
    }

    private void OnDestroy()
    {
        GameModeManager.RemoveModeChangeListened(OnModeChanged);
    }

    void OnModeChanged(BaseMode _newMode)
    {
        if (_newMode.GetType().Name == mode)
        {
            ObjectPool.ReleaseToPool(gameObject);
        }
    }
}
