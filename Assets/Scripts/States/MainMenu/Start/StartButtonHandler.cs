using UnityEngine;
using UnityEngine.UI;

public class StartButtonHandler : MonoBehaviour
{
    public Button yourButton; //Drag the button into this slot in the Unity Inspector
    public State nextState; //Drag the desired State object into this slot in the Unity Inspector

    void Start()
    {
        yourButton.onClick.AddListener(StartGame); 
    }

    public void StartGame()
    {
        GameManager.Instance.ChangeState("MainMenuState");
    }
}