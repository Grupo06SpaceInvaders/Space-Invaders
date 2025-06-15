using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVida : MonoBehaviour
{
    public int vida = 6;
    private bool morto = false;
    public static int  vidaui = 2 ;
    public GameObject losescreen;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tiroinimigo")
        {
            vida += -1;
            if (vida <= 0)
            {
                Destroy(this.gameObject);
                losescreen.SetActive(true);
            }
        }
    }

    private void Update()
    {
        if (vida == 6)
        {
            vidaui = 3;
        }

        else if (vida == 4)
        {
            vidaui = 2;
        }
        else if (vida == 2)
        {
            vidaui = 1;
        }
        else if (vida == 0)
        {
            vidaui = 0;
        }
    }
}