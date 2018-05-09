using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour 
{
    [SerializeField] private GameObject coinParticles;
    [SerializeField] private float particlesDuration;

    void OnTriggerEnter(Collider other)
    {
        ScoreManager.Instance.Score++;
        GameObject sparks = Instantiate(coinParticles, transform.position, transform.rotation);
        Destroy(coinParticles.gameObject, particlesDuration);
        Destroy(gameObject);
    }
}
