using UnityEngine;

public class SalvarVida : MonoBehaviour
{
    void Start()
    {
        // Salvando a vida do jogador (exemplo: 3)
        int vida = 3;
        PlayerPrefs.SetInt("VidaDoJogador", vida);
        PlayerPrefs.Save(); // Salva no disco

        // Carregando a vida do jogador
        int vidaCarregada = PlayerPrefs.GetInt("VidaDoJogador", 3);
        Debug.Log("Vida carregada: " + vidaCarregada);
    }
}
