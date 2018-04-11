using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHandMovement : MonoBehaviour
{
    [SerializeField]
    private float timeBetweenMoves;
    [SerializeField]
    private float totalMovingTime;
    [SerializeField]
    private float rotationSpeed;

    private void Awake()
    {
        InvokeRepeating("RotateHand", timeBetweenMoves, timeBetweenMoves);
        Invoke("CancelRotation", totalMovingTime);
    }

    private void RotateHand()
    {
        transform.Rotate(0, 0, -rotationSpeed);
    }

    private void CancelRotation()
    {
        CancelInvoke("RotateHand");
    }
}
