using StarterAssets;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float gameDuration = 120f; // 2 minutos
    private float timeRemaining;
    private bool isPaused = false;

    private UIManager uiManager;
    private ThirdPersonController playerController; // o el script que controle al jugador

    void Start()
    {
        timeRemaining = gameDuration;
        uiManager = FindObjectOfType<UIManager>();
        playerController = FindObjectOfType<ThirdPersonController>(); // busca tu script del jugador
    }

    void Update()
    {
        if (isPaused) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            GameOver();
        }

        string formatted = FormatTime(timeRemaining);
        uiManager.UpdateTimer(formatted);
    }

    // ================== PAUSA ==================
    public void PauseGame(bool state)
    {
        isPaused = state;
        Time.timeScale = state ? 0 : 1;
        uiManager.TogglePausePanel(state);

        if (playerController != null)
            playerController.enabled = !state; // bloquea al jugador
    }

    // ================== GAME OVER ==================
    private void GameOver()
    {
        PauseGame(true); // esto detiene todo
        uiManager.ShowGameOver(FindObjectOfType<ScoreManager>().GetScore());
    }

    // ================== FORMATO TIEMPO ==================
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
