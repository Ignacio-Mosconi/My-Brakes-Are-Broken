using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float acceleration;
    [SerializeField] private float turningSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private AudioSource accelerationSound;
    [SerializeField] private float streetObstacleSpeedReduction;
    private Rigidbody rigidBody;
    private bool[] canTurn = { true, true };

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float turn = Input.GetAxis("Horizontal");

        if (rigidBody.velocity.z < maxSpeed)
            rigidBody.AddForce(0, 0, acceleration * Time.deltaTime, ForceMode.Acceleration);
        if ((turn < 0 && canTurn[0]) || (turn > 0 && canTurn[1]))
            rigidBody.AddRelativeForce(turningSpeed * turn * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    public void StopMoving()
    {
        enabled = false;
        accelerationSound.Stop();
    }

    public void Decelerate()
    {
        rigidBody.AddForce(0, 0, -streetObstacleSpeedReduction, ForceMode.VelocityChange);
    }

    public bool CanTurnLeft
    {
        get { return canTurn[0]; }
        set { canTurn[0] = value; }
    }

    public bool CanTurnRight
    {
        get { return canTurn[1]; }
        set { canTurn[1] = value; }
    }
}
