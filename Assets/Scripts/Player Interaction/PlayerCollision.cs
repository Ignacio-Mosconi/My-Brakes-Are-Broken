using UnityEngine;
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(AudioSource))]

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private AudioSource acceleration;
    [SerializeField] private AudioSource crash;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("Obstacle"))
        {
            playerMovement.enabled = false;
            acceleration.Stop();
            crash.Play();
            FindObjectOfType<GameManager>().EndGame();
        }
        else
            if (collisionInfo.collider.CompareTag("Road") && collisionInfo.transform.position.y > 3)
                playerMovement.CanTurn = false;
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("Road"))
            playerMovement.CanTurn = true;
    }
}