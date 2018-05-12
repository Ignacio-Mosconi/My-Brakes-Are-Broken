using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour 
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject hudUI;
    private static bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                Pause();
            else
                Resume();
        }
    }

    void Pause()
    {
        if (!LevelManager.Instance.GameOver)
        {
            pauseMenuUI.SetActive(true);
            hudUI.SetActive(false);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        hudUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
  
    public static bool IsPaused
    {
        get { return isPaused; }
    }
}
