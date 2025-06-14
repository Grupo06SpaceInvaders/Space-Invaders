using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float health = 1;
    [SerializeField] private ScoreGiver scoreGiver;

    private void Update()
    {
        if (health <= 0)
        {
            GlobalVariables.enemyKilled++;
            Destroy(this.gameObject);
        }
    }
}
