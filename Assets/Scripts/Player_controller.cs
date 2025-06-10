using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private PlayerMovimento movimento;
    [SerializeField] private PlayerMira mira;
    [SerializeField] private PlayerTiro tiro;
    [SerializeField] private PlayerVida vida;

    void Update()
    {
        if (vida.EstaMorto())
        {
            movimento.enabled = false;
            mira.enabled = false;
            tiro.enabled = false;
        }
    }
}
