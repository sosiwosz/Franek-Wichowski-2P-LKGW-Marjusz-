using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private ScoreManager scoreManager;

    public static GameManager Instance { get; private set; }

    public int world { get; private set; }
    public int stage { get; private set; }
    public int lives { get; private set; }
    public int scoreCount { get; private set; }

    private void Awake()
    {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    private void Start()
    {
        ScoreManager.scoreCount = 0;
        Application.targetFrameRate = 60;
        scoreManager = FindObjectOfType<ScoreManager>();

        NewGame();
    }

    public void NewGame()
    {
        lives = 1;

        LoadLevel(1, 1);
        ScoreManager.scoreCount = 0;
    }

    public void GameOver()
    {

        NewGame();
    }

    public void LoadLevel(int world, int stage)
    {
        this.world = world;
        this.stage = stage;

        SceneManager.LoadScene($"{world}-{stage}");
    }

    public void NextLevel()
    {
        LoadLevel(world, stage + 1);
    }

    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        lives--;

        if (lives > 0) {
            LoadLevel(world, stage);
        } else {
            GameOver();
        }
    }

    public void AddCoin()
    {
        scoreCount += 1;

        if (scoreCount == 100)
        {
            scoreCount = 0;
            AddLife();
        }
    }

    public void AddLife()
    {
        lives++;
    }

}
