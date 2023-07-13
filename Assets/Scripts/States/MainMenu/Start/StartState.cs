using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartState : State
{
    public GameObject startScreenCanvas;
    
    public override void EnterState(GameManager gameManager)
    {
        this.gameManager = gameManager;
        this.stateName = "Start";
        startScreenCanvas = GameObject.Find("Canvas 1");
        startScreenCanvas.SetActive(true);
    }
    
    public override void Update()
    {
    }

    public override void ExitState()
    {
        startScreenCanvas.SetActive(false);
    }

}
