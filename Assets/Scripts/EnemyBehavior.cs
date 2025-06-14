using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private ScoreGiver scoreGiver;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("tiroPlayer"))
        {
            GlobalVariables.enemyKilled+=1;
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
    }
}
