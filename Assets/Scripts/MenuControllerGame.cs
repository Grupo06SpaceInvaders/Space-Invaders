using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControllerGame : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject opcoes;
    private int pausado;

    public void Start()
    {
        Time.timeScale = 1;
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape) &&  pausado == 0)
        {
            Time.timeScale = 0;
            mainmenu.SetActive(true);
            pausado = 1;
        }
    }
    public void ResumirJogo()
    {
        mainmenu.SetActive(false);
        Time.timeScale = 1;
        pausado = 0;
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
