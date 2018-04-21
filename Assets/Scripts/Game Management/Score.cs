using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform playerTrans;
    [SerializeField] private Text scoreText;

    void Update()
    {
        if (!FindObjectOfType<GameManager>().GetGameOver())
        {
            scoreText.text = playerTrans.position.z.ToString("0") + " m";
        }
        else
        {
            scoreText.enabled = false;
        }
    }
}
