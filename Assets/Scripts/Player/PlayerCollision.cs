using UnityEngine;
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(AudioSource))]

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private AudioSource skidSound;
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
                playerMovement.StopMoving();
                skidSound.Play();
                LevelManager.Instance.FailLevel();
                break;
            case "LeftEdge":
                playerMovement.CanTurnLeft = false;
                Debug.Log("Edge.");
                skidSound.Play();
                break;
            case "RightEdge":
                playerMovement.CanTurnRight = false;
                Debug.Log("Edge.");
                skidSound.Play();
                break;
            case "Street Obstacle":
                playerMovement.Decelerate();
                break;
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        switch (collisionInfo.collider.tag)
        {
            case "LeftEdge":
                playerMovement.CanTurnLeft = true;
                skidSound.Stop();
                break;
            case "RightEdge":
                playerMovement.CanTurnRight = true;
                skidSound.Stop();
                break;
        }
    }
}