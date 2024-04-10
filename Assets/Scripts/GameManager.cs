using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameover;
    public GameObject gameOverUI;
    public SceneFader sceneFader;
    public GameObject levelCompleteUI;
    public GameObject virtualCamera;
    void Start()
    {
        gameover = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(gameover)
        {
            return;
        }
        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        virtualCamera.SetActive(true);
        gameover = true;
        gameOverUI.SetActive(true);
        // StartCoroutine(DelayActive());
    }

    public void WinLevel()
    {
        gameover = true;
        levelCompleteUI.SetActive(true);
    }

    IEnumerator DelayActive()
    {
        yield return new WaitForSeconds(3);
        gameOverUI.SetActive(true);
    }
}
