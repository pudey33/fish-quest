using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FishingState : State
{
    public override void EnterState(GameManager gameManager)
    {
        this.gameManager = gameManager;
        this.stateName = "Fishing"; //has to match the name of a gameobject with this state inside of it
    }

    public override void Update()
    {
    }

    public override void ExitState()
    {
    }
}
