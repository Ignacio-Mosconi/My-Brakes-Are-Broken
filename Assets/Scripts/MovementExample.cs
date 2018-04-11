using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementExample : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float rotationSpeed;

    private void Update()
    {
        if (Input.GetButton("MoveForward"))
            transform.Translate(0, 0, movementSpeed * Time.deltaTime);
        if (Input.GetButton("MoveBackwards"))
            transform.Translate(0, 0, -movementSpeed * Time.deltaTime);
        if (Input.GetButton("RotateLeft"))
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        if (Input.GetButton("RotateRight"))
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
