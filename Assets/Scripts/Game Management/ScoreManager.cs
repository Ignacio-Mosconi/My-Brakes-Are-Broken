using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour 
{
    private static ScoreManager instance;
    private int score;

    void Awake()
    {
        if (Instance == this)
            Debug.Log("The Score Manager has been initialized correctly.", gameObject);
        else
            Debug.LogError("The scene already had a Score Manager.", Instance);
    }

    public static ScoreManager Instance
    {
        get
        {
            if (!instance)
                instance = FindObjectOfType<ScoreManager>();
            if (!instance)
            {
                GameObject gameObj = new GameObject("Score Manager");
                instance = gameObj.AddComponent<ScoreManager>();
            }
            return instance;
        }
    }

    public int Score
    {
        get { return score; }
    }
}
