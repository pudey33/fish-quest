using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public State currentState;

    // Start is called before the first frame update
    void Start()
    {
        // Create a new instance of MainMenuState and set it as the current state.
        //This enters the GameState machine when the Game Manager is created.
        ChangeState(new StartState());
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

        //Log what state we are in
        Debug.Log("Now Entering the " + currentState.name);
    }

    // Update is called once per frame
    void Update()
    {
        currentState?.Update();
    }
}
