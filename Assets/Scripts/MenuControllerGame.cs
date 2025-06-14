using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControllerGame : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject opcoes;

    public void Start()
    {
        Time.timeScale = 1;
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            mainmenu.SetActive(true);
        }
    }
    public void ResumirJogo()
    {
        mainmenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpcoesJogo()
    {
        mainmenu.SetActive(false);
        opcoes.SetActive(true);
    }

    public void SairOpcoes()
    {
        mainmenu.SetActive(true);
        opcoes.SetActive(false);
    }

    public void VoltarAoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
