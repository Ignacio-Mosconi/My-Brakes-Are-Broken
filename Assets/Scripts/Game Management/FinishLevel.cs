using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    void OnTriggerEnter()
    {
        gameManager.CompleteLevel();
    }
}
