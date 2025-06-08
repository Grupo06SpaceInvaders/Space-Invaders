using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject menuprincipal;
    public GameObject menuhighscore;
    public GameObject slideropcoes;

    public void Jogar()
    {
        SceneManager.LoadScene(1);
    }
    public void HighScoreMenu()
    {
        menuprincipal.SetActive(false);
        menuhighscore.SetActive(true);
    }

    public void HighScoreMenuReturn()
    {
        menuhighscore.SetActive(false);
        menuprincipal.SetActive(true);
    }

    public void Opcoes()
    {
        menuprincipal.SetActive(false);
        slideropcoes.SetActive(true);
    }

    public void Voltarmenuopcoes()
    {
        menuprincipal.SetActive(true);
        slideropcoes.SetActive(false);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
