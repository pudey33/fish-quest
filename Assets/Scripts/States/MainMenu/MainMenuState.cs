using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuState : State
{
    public GameObject mainMenuScreenCanvas;

    public override void EnterState(GameManager gameManager)
    {
        this.gameManager = gameManager;
        this.stateName = "Main Menu";
        mainMenuScreenCanvas.SetActive(true);
    }

    public override void Update()
    {
    }

    public override void ExitState()
    {
        //note: LoadScene called in other states unloads the mainMenu scene automatically
    }
}
