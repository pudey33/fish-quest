using UnityEngine;
using UnityEngine.UI;

public class StartButtonHandler : MonoBehaviour
{
    public Button yourButton; //Drag the button into this slot in the Unity Inspector
    public State nextState; //Drag the desired State object into this slot in the Unity Inspector

    void Start()
    {
        nextState = new MainMenuState();
        yourButton.onClick.AddListener(ChangeGameState); 
    }

    public void ChangeGameState()
    {
        GameManager.Instance.ChangeState(nextState);
    }
}