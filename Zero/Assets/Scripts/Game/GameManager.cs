using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject pausePanel;
    public GameObject game_overPanel;
    public LevelManager levelManager;

    public void Pause()
    {
        Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
        if (!pausePanel.activeSelf)
        {
            pausePanel.SetActive(true);
        } else
        {
            pausePanel.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
        game_overPanel.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
        levelManager.ChangeScene(1);
    }
}
