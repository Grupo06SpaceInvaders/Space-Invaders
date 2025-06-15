using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public static object GlobalVariables { get; internal set; }

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }


    private int score;
    private int Highscore;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        Highscore = PlayerPrefs.GetInt("highscoreKey", 0);
    }

    public void ChangeScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }

    public void TrySaveAsHighscore()
    {
        if (score > Highscore)
        {
            Highscore = score;
            PlayerPrefs.SetInt("highscoreKey", Highscore);
        }
    }
}