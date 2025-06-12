using UnityEngine;

public class PlayerTiro : MonoBehaviour
{
    public GameObject prefabTiro;
    public Transform spawnTiro;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shotObj = Instantiate(prefabTiro, spawnTiro.position, Quaternion.identity);


        }
    }
}