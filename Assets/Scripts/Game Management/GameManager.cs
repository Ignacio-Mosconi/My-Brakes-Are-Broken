using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform playerTrans;
    [SerializeField] private GameObject completeLevelUI;
    [SerializeField] private float restartDelay;
    private bool gameOver = false;
    private int finalScore;

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {
        if (!gameOver)
        {
            gameOver = true;
            finalScore = Mathf.RoundToInt(playerTrans.position.z);
            Invoke("RestartLevel", restartDelay);
        }
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

    public bool GetGameOver()
    {
        return gameOver;
    }
}
