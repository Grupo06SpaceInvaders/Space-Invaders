using UnityEngine;

public class ScoreGiver : MonoBehaviour
{
    [SerializeField] private int score;

    [ContextMenu(nameof(GiveScore))]
    public void GiveScore()
    {
        ScoreManager.Instance.Score += score;
    }

#if UNITY_EDITOR
    [ContextMenu(nameof(GiveScore), true)]
    private bool CanGiveScoreEditor()
    {
        return UnityEditor.EditorApplication.isPlaying;
    }
#endif
}
