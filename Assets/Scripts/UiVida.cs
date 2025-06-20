using UnityEngine;
using UnityEngine.UI;

public class UIVida : MonoBehaviour
{
    public Image[] coracoes;
    public Sprite coracaoCheio, coracaoVazio;
    public  static PlayerVida vida;

    void OnEnable() => PlayerVida.OnVidaAtualizada += AtualizarVida;
    void OnDisable() => PlayerVida.OnVidaAtualizada -= AtualizarVida;

    void AtualizarVida(int vidaAtual)
    {
        for (int i = 0; i < coracoes.Length; i++)
            coracoes[i].sprite = i < vidaAtual ? coracaoCheio : coracaoVazio;
    }

    public void ChangeVida()
    {
        coracoes[PlayerVida.vidaui].sprite = coracaoVazio;
    }

    
}

