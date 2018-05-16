using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    [SerializeField] private GameObject completeLevelUI;
    [SerializeField] private GameObject failLevelUI;
    [SerializeField] private AudioSource music;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Transform playerTransform;
    private bool gameOver = false;

    void Awake()
    {
        if (Instance == this)
            Debug.Log("The Level Manager has been initialized correctly.", gameObject);
        else
            Debug.LogError("The scene already had a Level Manager.", Instance);
    }

    void Start()
    {
        Cursor.visible = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FailLevel()
    {
        if (!gameOver)
        {
            gameOver = true;
            music.Stop();
            failLevelUI.SetActive(true);
            GameManager.Instance.DistanceTraveled += playerTransform.position.z / 1000;
        }
    }

    public void CompleteLevel()
    {
        if (!gameOver)
        {
            playerMovement.StopMoving();
            gameOver = true;
            music.Stop();
            completeLevelUI.SetActive(true);
            GameManager.Instance.DistanceTraveled += playerTransform.position.z / 1000;
            GameManager.Instance.CoinsCollected += ScoreManager.Instance.Score;
        }
    }

    public static LevelManager Instance
    {
        get
        {
            if (!instance)
                instance = FindObjectOfType<LevelManager>();
            if (!instance)
            {
                GameObject gameObj = new GameObject("Level Manager");
                instance = gameObj.AddComponent<LevelManager>();
            }
            return instance;
        }
    }

    public bool GameOver
    {
        get { return gameOver; }
    }
}
