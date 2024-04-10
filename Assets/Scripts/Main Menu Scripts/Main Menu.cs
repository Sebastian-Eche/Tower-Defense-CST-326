using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Camera screenCamera;
    public string levelToLoad = "TowerDefense";
    public SceneFader sceneFader;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            screenCamera.ScreenPointToRay(mousePos);
        }
        
    }

    public void Play()
    {
        // alot of computation
        // FindObjectOfType<SceneFader>().FadeTo(levelToLoad);
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
