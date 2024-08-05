using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenager : MonoBehaviour
{
    public static Vector2 bottomleft;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool gameStarted;
    public GameObject GetReady;
    public static int gameScore;
    public GameObject score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        bottomleft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
    }
    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Start()
    {
        gameOver = false;
        gameStarted = false;
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        score.SetActive(false);
        gameScore = score.GetComponent<Score>().GetScore();
    }
    public void GameHasStarted()
    {
        gameStarted = true;
        GetReady.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
