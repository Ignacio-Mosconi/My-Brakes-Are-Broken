﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelMenu : MonoBehaviour 
{
    public void Restart()
    {
        LevelManager.Instance.RestartLevel();
    }

    public void LoadNext()
    {
        LevelManager.Instance.LoadNextLevel();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
