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
    private bool moveLeft = false;
    private bool moveRight = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey("a"))
        {
            moveLeft = true;
        }
        if (Input.GetKey("d"))
        {
            moveRight = true;
        }
    }

    void FixedUpdate()
    {
        rigidBody.AddForce(0, 0, acceleration * Time.deltaTime, ForceMode.Acceleration);
        if (moveLeft)
        {
            rigidBody.AddRelativeForce(-turningSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            moveLeft = false;
        }
        if (moveRight)
        {
            rigidBody.AddRelativeForce(turningSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            moveRight = false;
        }

        if (rigidBody.position.y < fallingLimit)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
