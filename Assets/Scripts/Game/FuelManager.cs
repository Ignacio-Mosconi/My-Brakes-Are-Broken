using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelManager : MonoBehaviour 
{
    private static FuelManager instance;
    [SerializeField] private float fuelAmount;

    void Awake()
    {
        if (Instance == this)
            Debug.Log("The Fuel Manager has been initialized correctly.", gameObject);
        else
            Debug.LogError("The level already had a Fuel Manager.", Instance);
    }

    void Update()
    {
        fuelAmount -= Time.deltaTime;
        if (fuelAmount <= 0)
            LevelManager.Instance.FailLevel();
    }

    public FuelManager Instance
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
}
