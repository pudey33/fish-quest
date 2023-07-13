using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NewGameButtonHandler : MonoBehaviour
{
    public GameManager gameManager;
    void Start()
    {
        //TODO: create a newGameState for starting a new game!
        GetComponent<Button>().onClick.AddListener(HandleClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HandleClick()
    {
        gameManager.ChangeScene("FishingScene", "FishingState");
    }
}
