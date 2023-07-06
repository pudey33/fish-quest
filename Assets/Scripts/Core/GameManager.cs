using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private State currentState;

    // This can be called to switch to a different state
    public void ChangeState(State newState)
    {
        currentState?.ExitState();
        currentState = newState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState?.Update();
    }
}
