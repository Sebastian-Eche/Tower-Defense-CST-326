using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausedMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        if(pauseMenu.activeSelf)
        {
            Time.timeScale = 0f;
            // Time.fixedDeltaTime = 0f;
        }else{
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }
}
