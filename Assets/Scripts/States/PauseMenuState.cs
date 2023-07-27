using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : State
{
    public override void EnterState(GameManager gameManager)
    {
        this.gameManager = gameManager;
        this.name = "Pause";
    }

    public override void Update()
    {
    }

    public override void ExitState()
    {
    }
}
