using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopState : State
{
    public override void EnterState(GameManager gameManager)
    {
        this.gameManager = gameManager;
        this.name = "Shop";
    }

    public override void Update()
    {
    }

    public override void ExitState()
    {
    }
}
