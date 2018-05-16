using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    private static GameManager instance;
    [SerializeField] private float volumeSliderValue;
    private float distanceTraveled = 0;
    private int coinsCollected = 0;

    void Awake()
    {
        if (Instance == this)
        {
            Debug.Log("The Game Manager has been initialized correctly.", gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        Screen.SetResolution(480, 854, false);
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

    public float DistanceTraveled
    {
        get { return distanceTraveled; }
        set { distanceTraveled = value; }
    }

    public int CoinsCollected
    {
        get { return coinsCollected; }
        set { coinsCollected = value; }
    }
}
