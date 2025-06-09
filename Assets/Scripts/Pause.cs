using UnityEngine;

public class Pausa : MonoBehaviour
{
    bool ispaused = false;
    public GameObject PauseMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(ispaused == false)
            {
                Pause();
            }
            else if (ispaused == true)
            {
                Play();
            }
        }
    }
    public void Pause()
    {
            Time.timeScale = 0f;
            ispaused = true;
            PauseMenu.SetActive(true);
    }
    public void Play()
    {
            Time.timeScale = 1f;
            ispaused = false;
            PauseMenu.SetActive(false);
    }
}
