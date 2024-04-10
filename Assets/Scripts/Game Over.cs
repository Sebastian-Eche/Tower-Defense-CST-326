using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI wavesSurvivedText;
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";

    void OnEnable() {
        wavesSurvivedText.text = PlayerStats.Waves.ToString();
    }

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
