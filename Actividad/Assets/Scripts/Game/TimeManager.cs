using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float gameDuration = 120f; // 2 minutos
    private float timeRemaining;
    private bool isPaused = false;

    private UIManager uiManager;

    void Start()
    {
        timeRemaining = gameDuration;
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        if (isPaused) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            uiManager.ShowGameOver(FindObjectOfType<ScoreManager>().GetScore());
        }

        string formatted = FormatTime(timeRemaining);
        uiManager.UpdateTimer(formatted);
    }

    public void PauseGame(bool state)
    {
        isPaused = state;
        Time.timeScale = state ? 0 : 1;
        uiManager.TogglePausePanel(state);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
