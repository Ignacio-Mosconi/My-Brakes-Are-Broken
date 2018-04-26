using UnityEngine;
using UnityEngine.UI;

public class DistanceUI : MonoBehaviour
{
    [SerializeField] private Transform playerTrans;
    [SerializeField] private Text distanceText;

    void Update()
    {
        if (!LevelManager.Instance.GameOver)
        {
            distanceText.text = playerTrans.position.z.ToString("0") + " m";
        }
        else
        {
            distanceText.enabled = false;
        }
    }
}
