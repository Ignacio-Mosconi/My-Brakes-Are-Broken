using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;

    private void Update()
    {
        transform.Translate(0, 0, bulletSpeed * Time.deltaTime);
    }
}
