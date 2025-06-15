using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int score;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("tiroPlayer"))
        {
            ScoreManager.Instance.ChangeScore(score);
            GlobalVariables.enemyKilled+=1;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
