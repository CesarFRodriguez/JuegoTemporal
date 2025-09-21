using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("HUD Elements")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI playerNameText;

    [Header("Panels")]
    public GameObject pausePanel;
    public GameObject gameOverPanel;

    [Header("Game Over Elements")]
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        // Inicializar UI
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void UpdateTimer(string formattedTime)
    {
        timerText.text = formattedTime;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Puntos: " + score;
    }

    public void UpdatePlayerName(string name)
    {
        playerNameText.text = name;
    }


    public void TogglePausePanel(bool state)
    {
        pausePanel.SetActive(state);
    }

    public void ShowGameOver(int score)
    {
        gameOverPanel.SetActive(true);
        //finalScoreText.text = "Puntaje final: " + score;
    }
}

       
