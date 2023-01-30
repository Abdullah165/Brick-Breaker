using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    int score;
    int bestScore;
    [SerializeField] Text scoreText;
    [SerializeField] Text bestScoreText;
    [SerializeField] Text LevelText;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("bestScore", 0);
        bestScoreText.text = bestScore.ToString();
        LevelText.text = (SceneManager.GetActiveScene().buildIndex + 1).ToString();
    }

    public void IncreaseScore()
    {
        score+=20;
        scoreText.text = score.ToString();
    }

    public void UpdateBestScore()
    {
        if (bestScore < score)
            PlayerPrefs.SetInt("bestScore", score);
    }
}
