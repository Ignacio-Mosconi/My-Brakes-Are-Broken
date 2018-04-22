using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerTrans;
    [SerializeField] private Vector3 offset;

    void Update()
    {
        transform.position = playerTrans.position + offset;
    }
}
