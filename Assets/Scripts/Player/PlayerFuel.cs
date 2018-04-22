using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFuel : MonoBehaviour 
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float amount;
	
	void Update() 
	{
        amount -= Time.deltaTime;
        if (amount < 0)
            gameManager.EndGame();
	}

    public float Amount
    {
        get { return amount; }
        set { amount = value; }
    }
}
