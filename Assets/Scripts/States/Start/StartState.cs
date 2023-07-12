using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartState : State
{
    public string stateName = "Start";
    public override void EnterState(GameManager gameManager)
    {
        this.gameManager = gameManager;
        this.name = stateName;
    }

    void Start()
    {
    }
    public override void Update()
    {
    }

    public override void ExitState()
    {
        // Insert code to handle exiting the Start state here
    }

    public void StartGame()
    {
            gameManager.ChangeState(new MainMenuState());
    }
}
