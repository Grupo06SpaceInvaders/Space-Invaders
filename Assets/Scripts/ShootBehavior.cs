using UnityEngine;

public class ShootBehavior : MonoBehaviour
{
    public float damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " colidiu com " + other.gameObject.name);
    }
}
