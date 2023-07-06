using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected GameManager gameManager;

    // public void GameState(GameManager gameManager)
    // {
    //     this.gameManager = gameManager;
    // }

    public abstract void EnterState(GameManager gameManager);
    public abstract void Update();
    public abstract void ExitState();
}
