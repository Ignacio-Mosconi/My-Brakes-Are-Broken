using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class ObstacleCrash : MonoBehaviour 
{
    [SerializeField] private AudioSource crash;
	
	void OnCollisionEnter(Collision collisionInfo) 
	{
		if (collisionInfo.collider.CompareTag("Player"))
        {
            crash.Play();
        }
	}
}
