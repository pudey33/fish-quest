using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public State currentState;
    private string nextSceneName;
    private string nextStateName;

    // Start is called before the first frame update
    void Start()
    {
        //This enters the GameState pattern when the game is initialized.
        ChangeState("StartState");
    }

    protected override void Awake() 
    {
        base.Awake();
        DontDestroyOnLoad(gameObject); //this line persists the GameManager in between scenes
    }

    // This can be called to switch to a different state
    public void ChangeState(string newStateName)
    {
        GameObject nextStateGameObject = GameObject.Find(newStateName);
        State newState = (State)nextStateGameObject.GetComponent(newStateName);
        currentState?.ExitState(); //the question mark here skips the line if currentState doesn't exist yet.
        currentState = newState;
        currentState.EnterState(this);

        //Log what state we are in
        UnityEngine.Debug.Log("Now Entering the " + currentState.stateName + " state.");
    }

    //Swap scenes then enter first scene state.
    public void ChangeScene(string sceneName, string stateName)
    {
        this.nextSceneName = sceneName;
        this.nextStateName = stateName; // these pocket style vars reminding me of javascript async
        StartCoroutine(LoadNextStateScene());
    }

    // Loading scene async so I can know when it is done to change to the next state.
    // If this seems backwards, it kind of is. We could just do scene specific gameManagers with hardcoded firstStates,
    //  but then they wouldn't be technically be Singletons!
    private IEnumerator LoadNextStateScene()
    {
        // Start loading the next scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextSceneName, LoadSceneMode.Additive);

        // Wait until the scene has finished loading
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Get the reference to the next state GameObject in the loaded scene
        Scene nextScene = SceneManager.GetSceneByName(nextSceneName);
        Scene currentScene = SceneManager.GetActiveScene();

        if (nextScene.isLoaded && nextStateName != null)
        {
            ChangeState(nextStateName);
        }
        else
        {
            UnityEngine.Debug.LogWarning("Failed to find the next state in the loaded scene.");
        }

        // Unload the previous scene
        SceneManager.UnloadSceneAsync(currentScene.name);
    }

    // Update is called once per frame
    void Update()
    {
        currentState?.Update();
    }
}
