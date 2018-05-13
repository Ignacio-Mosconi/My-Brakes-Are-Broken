using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    private static GameManager instance;
    [SerializeField] private float volumeSliderValue;

    void Awake()
    {
        if (Instance == this)
        {
            Debug.Log("The Game Manager has been initialized correctly.", gameObject);
            DontDestroyOnLoad(gameObject);
        }
        else
            Debug.LogError("The game already had a Game Manager.", Instance);
    }

    public static GameManager Instance
    {
        get
        {
            if (!instance)
                instance = FindObjectOfType<GameManager>();
            if (!instance)
            {
                GameObject gameObj = new GameObject("Game Manager");
                instance = gameObj.AddComponent<GameManager>();
            }
            return instance;
        }
    }

    public float VolumeSliderValue
    {
        get { return volumeSliderValue; }
        set { volumeSliderValue = value; }
    }
}
