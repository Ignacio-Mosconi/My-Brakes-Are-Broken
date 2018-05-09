using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour 
{
    private static FuelManager instance;
    [SerializeField] private float fuelAmount;
    [SerializeField] private Image fuelBar;
    private float maxFuel;

    void Awake()
    {
        if (Instance == this)
        {
            Debug.Log("The Fuel Manager has been initialized correctly.", gameObject);
            maxFuel = fuelAmount;
        }
        else
            Debug.LogError("The level already had a Fuel Manager.", Instance);
    }

    void Update()
    {
        fuelAmount -= Time.deltaTime;
        if (fuelAmount <= 0)
            LevelManager.Instance.FailLevel();
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
    }

    public float MaxFuel
    {
        get { return maxFuel; }
    }
}
