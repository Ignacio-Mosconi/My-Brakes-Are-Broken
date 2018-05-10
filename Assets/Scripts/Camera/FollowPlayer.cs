using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerTransorm;
    [SerializeField] private Vector3 offset;

    void Update()
    {
        transform.position = playerTransorm.position + offset;
    }
}
