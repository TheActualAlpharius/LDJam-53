using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMode : BaseMode
{
    private CameraMover cameraMover;

    public ScoreMode()
    {
        cameraMover = GameObject.FindObjectOfType<CameraMover>();
    }

    public override void TransitionIn()
    {
        cameraMover.StartFloating();
    }

    public override void TransitionOut()
    {
        cameraMover.StopFloating();
    }

    public override void Update()
    {

    }

    public override void FixedUpdate()
    {

    }
}
