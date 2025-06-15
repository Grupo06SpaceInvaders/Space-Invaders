using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreDisplayer : MonoBehaviour
{
    // !! Nao entendi nada, entao so comentei e refiz de outra maneira usando o 'Enemy Behavior + Score Manager'

    /*
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        ScoreManager.Instance.OnScoreChange += UpdateScore;
    }

    private void OnDestroy()
    {
        if (!ScoreManager.HasIntance) return;
        ScoreManager.Instance.OnScoreChange -= UpdateScore;
    }

    private void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
    */
}
