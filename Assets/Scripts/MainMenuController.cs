using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject menuprincipal;
    public GameObject menuhighscore;
    public GameObject menuopcoes;
    
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
        menuopcoes.SetActive(true);
        menuprincipal.SetActive(false);
    }
    
    public void SairOpcoes()
    {
        menuopcoes.SetActive(false);
        menuprincipal.SetActive(true);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
