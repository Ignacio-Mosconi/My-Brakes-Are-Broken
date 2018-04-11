using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float firstShotDelay;
    [SerializeField]
    private float delayBetweenShots;

    private void Awake()
    {
        Invoke("Shoot", firstShotDelay);
	}

    private void Shoot()
    {
        GameObject bul = Instantiate(bullet);
        bul.transform.position = transform.position;
        bul.transform.rotation = transform.rotation;

        Invoke("Shoot", delayBetweenShots);
    }
}
