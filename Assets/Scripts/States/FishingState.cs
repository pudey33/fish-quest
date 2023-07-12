using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingState : State
{
    public string stateName = "Fishing";
    public override void EnterState(GameManager gameManager)
    {
        this.gameManager = gameManager;
        this.name = stateName;
    }

    public override void Update()
    {
    }

    public override void ExitState()
    {
    }
}
