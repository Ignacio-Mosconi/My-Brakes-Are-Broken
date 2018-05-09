using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour 
{
    private static ScoreManager instance;
    [SerializeField] private UnityEvent onScoreChange;
    private int score = 0;

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

    public UnityEvent OnScoreChange
    {
        get { return onScoreChange; }
    }

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            OnScoreChange.Invoke();
        }
    }
}
