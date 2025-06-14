using UnityEngine;

public class PlayerTiro : MonoBehaviour
{
    public GameObject prefabTiro;
    public Transform spawnTiro;

    AudioPlayer audioPlayer; //Referencia do Script de Audio

    void Start()
    {
        audioPlayer = GetComponent<AudioPlayer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shotObj = Instantiate(prefabTiro, spawnTiro.position, Quaternion.identity);

            audioPlayer.PlayAudio(0); //Tocar som do tiro
        }
    }
}