using UnityEngine;
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(AudioSource))]

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioSource acceleration;
    [SerializeField] private AudioSource skid;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        switch (collisionInfo.collider.tag)
        {
            case "Obstacle":
                playerMovement.enabled = false;
                acceleration.Stop();
                skid.Play();
                gameManager.EndGame();
                break;
            case "LeftEdge":
                playerMovement.CanTurnLeft = false;
                skid.Play();
                break;
            case "RightEdge":
                playerMovement.CanTurnRight = false;
                skid.Play();
                break;
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        switch (collisionInfo.collider.tag)
        {
            case "LeftEdge":
                playerMovement.CanTurnLeft = true;
                skid.Stop();
                break;
            case "RightEdge":
                playerMovement.CanTurnRight = true;
                skid.Stop();
                break;
        }
    }
}