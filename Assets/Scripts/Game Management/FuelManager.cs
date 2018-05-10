using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FuelManager : MonoBehaviour 
{
    private static FuelManager instance;
    [SerializeField] private float fuelAmount;
    [SerializeField] private Image fuelBar;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private AudioSource playerAcceleration;
    private float maxFuel;

    void Awake()
    {
        if (Instance == this)
            Debug.Log("The Fuel Manager has been initialized correctly.", gameObject);
        else
            Debug.LogError("The level already had a Fuel Manager.", Instance);
    }

    void Start()
    {
        maxFuel = fuelAmount;
    }

    void Update()
    {
        fuelAmount -= Time.deltaTime;
        if (fuelAmount <= 0)
        {
            playerMovement.enabled = false;
            playerAcceleration.Stop();
            LevelManager.Instance.FailLevel();
        }
    }

    public static FuelManager Instance
    {
        get
        {
            if (!instance)
                instance = FindObjectOfType<FuelManager>();
            if (!instance)
            {
                GameObject gameObj = new GameObject("Fuel Manager");
                instance = gameObj.AddComponent<FuelManager>();
            }
            return instance;
        }
    }

    public float FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }

    public float MaxFuel
    {
        get { return maxFuel; }
    }
}
