using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class CoinPickUp : MonoBehaviour 
{
    [SerializeField] private GameObject coinParticles;
    [SerializeField] private AudioSource pickUpSound;

    void OnTriggerEnter(Collider other)
    {
        if (!LevelManager.Instance.GameOver)
        {
            ScoreManager.Instance.Score++;
            pickUpSound.Play();
            coinParticles = Instantiate(coinParticles, transform.position, transform.rotation);
            Destroy(gameObject, pickUpSound.clip.length);
        }
    }
}
