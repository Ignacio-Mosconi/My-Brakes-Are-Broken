using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class GasCanPickUp : MonoBehaviour 
{
    [SerializeField] private GameObject gasCanParticles;
    [SerializeField] private AudioSource pickUpSound;
    [SerializeField] private float fuelRestoreAmount;

    void OnTriggerEnter(Collider other)
    {
        if (!LevelManager.Instance.GameOver && FuelManager.Instance.FuelAmount < FuelManager.Instance.MaxFuel)
        {
            FuelManager.Instance.FuelAmount = (FuelManager.Instance.FuelAmount + fuelRestoreAmount < FuelManager.Instance.MaxFuel) ?
                FuelManager.Instance.FuelAmount + fuelRestoreAmount : FuelManager.Instance.MaxFuel;

            pickUpSound.Play();
            gasCanParticles = Instantiate(gasCanParticles, transform.position, transform.rotation);
            Destroy(gameObject, pickUpSound.clip.length);
        }
    }
}
