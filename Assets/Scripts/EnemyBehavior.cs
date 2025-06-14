using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private ScoreGiver scoreGiver;


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("colidiu");
        if (other.gameObject.CompareTag("tiroPlayer"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
    }
}
