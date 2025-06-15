using UnityEngine;

public class TiroController : MonoBehaviour
{
    public float velocidade = 100f;
    public float tempoDestruir = 5f;
    void Start()
    {
        Destroy(this.gameObject, tempoDestruir);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * velocidade * Time.deltaTime);
    }
    
}
   