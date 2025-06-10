using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovimento : MonoBehaviour
{
    public float velocidade = 10f;
    private CharacterController controller;

    public float limiteX = 70f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // Apenas o eixo X
        Vector3 move = new Vector3(h, 0f, 0f) * velocidade * Time.deltaTime;
        Vector3 next = transform.localPosition + move;

        // Limita o movimento no eixo X apenas
        if (next.x > limiteX || next.x < -limiteX)
            move.x = 0f;

        controller.Move(move);
    }
}
