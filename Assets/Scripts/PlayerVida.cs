using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVida : MonoBehaviour
{
    public int vida = 3;
    private bool morto = false;

    public static event Action<int> OnVidaAtualizada;

    public void ReceberDano(int quantidade)
    {
        if (morto) return;

        vida -= quantidade;
        OnVidaAtualizada?.Invoke(vida);

        if (vida <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        ScoreManager.Instance.TrySaveAsHighscore();
        SceneManager.LoadScene("Defeat");
        Debug.Log("Player morreu!");
        morto = true;
        gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    public bool EstaMorto()
    {
        return morto;
    }
}