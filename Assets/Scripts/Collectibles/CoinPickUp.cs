using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class CoinPickUp : MonoBehaviour 
{
    [SerializeField] private GameObject coinParticles;
    [SerializeField] private AudioSource pickUpSound;
    private BoxCollider boxCollider;

    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!LevelManager.Instance.GameOver && boxCollider.enabled)
        {
            BoxCollider boxCollider = gameObject.GetComponent<BoxCollider>();
            boxCollider.enabled = false;
            ScoreManager.Instance.Score++;
            pickUpSound.Play();
            coinParticles = Instantiate(coinParticles, transform.position, transform.rotation);
            Destroy(gameObject, pickUpSound.clip.length);
        }
    }
}
