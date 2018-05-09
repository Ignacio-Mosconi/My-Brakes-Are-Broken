using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class CoinPickUp : MonoBehaviour 
{
    [SerializeField] private GameObject coinParticles;
    [SerializeField] private AudioSource pickUpSound;
    [SerializeField] private float particlesDuration;

    void OnTriggerEnter(Collider other)
    {
        if (!LevelManager.Instance.GameOver)
        {
            ScoreManager.Instance.Score++;
            pickUpSound.Play();
            GameObject sparks = Instantiate(coinParticles, transform.position, transform.rotation);
            Destroy(sparks.gameObject, particlesDuration);
            Destroy(gameObject, pickUpSound.clip.length);
            //gameObject.SetActive(false);
        }
    }
}
