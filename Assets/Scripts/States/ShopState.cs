using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopState : State
{
    public string stateName = "Shop";
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
