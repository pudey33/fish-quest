using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ExitButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public GameManager gameManager;
    void Start()
    {
       GetComponent<Button>().onClick.AddListener(HandleClick); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleClick()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
