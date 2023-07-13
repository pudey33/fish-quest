using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected GameManager gameManager;
    public string stateName;

    // public void GameState(GameManager gameManager)
    // {
    //     this.gameManager = gameManager;
    // }
    public abstract void EnterState(GameManager gameManager);
    public abstract void Update(); //do I need this? ChatGPT said that states don't need to be updated every frame, but it also wrote this
    public abstract void ExitState();
}
