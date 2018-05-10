using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelManager : MonoBehaviour 
{
    private static FuelManager instance;
    [SerializeField] private float maxFuel;
    [SerializeField] private PlayerMovement playerMovement;
    private float fuelAmount = 0;

    void Awake()
    {
        if (Instance == this)
            Debug.Log("The Fuel Manager has been initialized correctly.", gameObject);
        else
            Debug.LogError("The level already had a Fuel Manager.", Instance);
    }

    void Start()
    {
        fuelAmount = maxFuel;
    }

    void Update()
    {
        fuelAmount -= Time.deltaTime;
        if (fuelAmount <= 0)
        {
            playerMovement.StopMoving();
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
