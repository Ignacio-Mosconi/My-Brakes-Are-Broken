using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour 
{
    void OnTriggerEnter(Collider other)
    {
        ScoreManager.Instance.Score++;
        Destroy(gameObject);
    }
}
