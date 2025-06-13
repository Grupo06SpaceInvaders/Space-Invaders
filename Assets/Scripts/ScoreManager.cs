using System;
using UnityEngine;

public class ScoreManager : MonoBehaviourSingleton<ScoreManager>
{
    private const string highscoreKey = "highscore";
    private int score;
   
    public int Score
    {
        get => score;
        set
        {
            score = Mathf.Max(value, 0);
            OnScoreChange?.Invoke(score);
        }
    }
    public int Highscore { get;  private set; }

    public event Action<int> OnScoreChange;

    private void Start()
    {
        Highscore = PlayerPrefs.GetInt(highscoreKey, 0);
    }

    public void TrySaveAsHighscore()
    {
        if (score > Highscore)
        {
            Highscore = Score;
            PlayerPrefs.SetInt(highscoreKey, Highscore);
        } 
    }
}