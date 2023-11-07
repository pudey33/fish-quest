using System;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public State currentState;
    public AsyncOperation asyncLoad;

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
        UnityEngine.Debug.Log("Inside ChangeState: " + newStateName + " asdf " + GameObject.Find(newStateName));
        try {
        GameObject nextStateGameObject = GameObject.Find(newStateName);
        State newState = (State)nextStateGameObject.GetComponent(newStateName);
        currentState?.ExitState(); //the question mark here skips the line if currentState doesn't exist yet.
        currentState = newState;
        currentState.EnterState(this);

        //Log what state we are in
        UnityEngine.Debug.Log("Now Entering the " + currentState.stateName + " state.");
        } catch(NullReferenceException e) {
            UnityEngine.Debug.LogError("Could not find the state GameObject with the corresponding state name: " + newStateName + ". Error: " + e);
        }
    }

    //Swap scenes then enter first scene state.
    //parameters: sceneName, stateName
    public void ChangeScene(string sceneName, string stateName)
    {
        UnityEngine.Debug.Log("Attempting to load scene: " + sceneName + ". Loading state: " + stateName + ".");
        StartCoroutine(LoadNextStateScene(sceneName, stateName));
    }

    // Loading scene async so I can know when it is done to change to the next state.
    // If this seems backwards, it kind of is. We could just do scene specific gameManagers with hardcoded firstStates,
    //  but then they wouldn't be technically be Singletons!
    private IEnumerator LoadNextStateScene(string nextSceneName, string nextStateName)
    {
        // Start loading the next scene asynchronously
        asyncLoad = SceneManager.LoadSceneAsync(nextSceneName, LoadSceneMode.Single);

        // Wait until the scene has finished loading
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Get the reference to the next state GameObject in the loaded scene
        Scene nextScene = SceneManager.GetSceneByName(nextSceneName);
        Scene currentScene = SceneManager.GetActiveScene();
        UnityEngine.Debug.Log("FUCK: " + currentScene.name + " fuck2" + nextScene.isLoaded);

        if (nextScene.isLoaded && nextStateName != null)
        {
            ChangeState(nextStateName);
            // Unload the previous scene
            SceneManager.UnloadSceneAsync(currentScene.name);
        }
        else
        {
            UnityEngine.Debug.LogWarning("Failed to find the next state in the loaded scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentState?.Update();
    }
}
