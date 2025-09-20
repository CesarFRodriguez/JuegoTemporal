using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        uiManager.UpdateScore(score); // inicializa la UI en 0
    }

    public void AddPoints(int points)
    {
        score += points;
        uiManager.UpdateScore(score);
    }

    public void ResetScore()
    {
        score = 0;
        uiManager.UpdateScore(score);
    }

    public int GetScore()
    {
        return score;
    }
}
