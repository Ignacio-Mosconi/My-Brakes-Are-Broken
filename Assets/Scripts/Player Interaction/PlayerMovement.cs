using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float acceleration;
    [SerializeField] private float turningSpeed;
    [SerializeField] private int fallingLimit;
    private Rigidbody rigidBody;
    private bool canTurn = true;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rigidBody.AddForce(0, 0, acceleration * Time.deltaTime, ForceMode.Acceleration);
        if (canTurn)
        {
            float turn = Input.GetAxis("Horizontal");
            rigidBody.AddRelativeForce(turningSpeed * turn * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (rigidBody.position.y < fallingLimit) 
           FindObjectOfType<GameManager>().EndGame();
    }

    public bool CanTurn
    {
        get { return canTurn; }
        set { canTurn = value; }
    }

}
