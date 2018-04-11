using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidBody;
    [SerializeField]
    private float acceleration = 1500;
    [SerializeField]
    private float turningSpeed = 100;
    [SerializeField]
    private int fallingLimit = -1;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rigidBody.AddForce(0, 0, acceleration * Time.deltaTime, ForceMode.Acceleration);
        float turn = Input.GetAxis("Horizontal");
        rigidBody.AddRelativeForce(turningSpeed * turn * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (rigidBody.position.y < fallingLimit) 
           FindObjectOfType<GameManager>().EndGame();
    }
}
