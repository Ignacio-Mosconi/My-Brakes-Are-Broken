using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFuel : MonoBehaviour 
{
    [SerializeField] private float amount;
	
	void Update() 
	{
        amount -= Time.deltaTime;
        if (amount < 0)
            LevelManager.Instance.EndGame();
	}

    public float Amount
    {
        get { return amount; }
        set { amount = value; }
    }
}
