using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FishopediaButtonHandler : MonoBehaviour
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
        string fishPath = Application.dataPath + "/Fish Data/SampleFish.json";
        List<Fish> fishData = JSONImporter.ImportFishData(fishPath);

        foreach(Fish f in fishData)
            UnityEngine.Debug.Log(f.name);
    }
}
