using UnityEngine;

public class PlayerTiro : MonoBehaviour
{
    public GameObject prefabTiro;
    public Transform pontoDisparo;
    public GameObject tela;


    void Start()
    {
        tela = GameObject.FindGameObjectWithTag("Tela");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefabTiro, pontoDisparo.position + pontoDisparo.forward, pontoDisparo.rotation, tela.transform);
        }
    }
}