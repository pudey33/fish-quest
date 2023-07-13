using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FishingState : State
{
    public string sceneName = "FishingScene";

    public override void EnterState(GameManager gameManager)
    {
        this.gameManager = gameManager;
        this.stateName = "Fishing";
        SceneManager.LoadScene(sceneName);
    }

    public override void Update()
    {
    }

    public override void ExitState()
    {
    }
}
