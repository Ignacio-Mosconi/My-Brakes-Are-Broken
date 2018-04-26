using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    void OnTriggerEnter()
    {
        LevelManager.Instance.CompleteLevel();
    }
}
