using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private State currentState;

    // Start is called before the first frame update
    void Start()
    {
        // Create a new instance of MainMenuState and set it as the current state.
        //This enters the GameState machine when the Game Manager is created.
        ChangeState(new MainMenuState());
    }

    protected override void Awake() 
    {
        base.Awake();
        DontDestroyOnLoad(gameObject); //this line persists the GameManager in between scenes
    }

    // This can be called to switch to a different state
    public void ChangeState(State newState)
    {
        currentState?.ExitState(); //the question mark here makes everything okay if currentState doesn't exist yet.
        currentState = newState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState?.Update();
    }
}
