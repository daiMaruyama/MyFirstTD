using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameSystem : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text scoreText;         // スコア表示用 
    private int score = 0;
    private bool isGameOver = false;

    void Start()
    {
        UpdateScoreText();
        gameOverPanel.SetActive(false);
    }

    public void SetIsGameover(bool value)
    {
        if (isGameOver) return;

        isGameOver = value;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            // Time.timeScale = 0f; ← 時間止めたければ使う
        }
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // スコアを増やす用（Enemyが倒されたときなどに呼ぶ）
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

}
