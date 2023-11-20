using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text scoreText;
    public TMP_Text scoreText2;
    public TMP_Text highscoreText;
    public TMP_Text highscoreText2;

    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "score: " + score.ToString();
        scoreText2.text = "score: " + score.ToString();
        highscoreText.text = "high score: " + highscore.ToString();
        highscoreText2.text = "high score: " + highscore.ToString();
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = "score: " + score.ToString();
        scoreText2.text = "score: " + score.ToString();

        if(highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
