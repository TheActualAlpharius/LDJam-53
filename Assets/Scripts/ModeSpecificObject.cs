using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSpecificObject : MonoBehaviour
{
    [SerializeField] string mode;

    // Start is called before the first frame update
    void Start()
    {
        GameModeManager.AddModeChangeListener(OnModeChanged);

        OnModeChanged(GameModeManager.GetMode());
    }

    private void OnDestroy()
    {
        GameModeManager.RemoveModeChangeListened(OnModeChanged);
    }

    void OnModeChanged(BaseMode _newMode)
    {
        this.gameObject.SetActive(_newMode.GetType().Name == mode);
    }
}
