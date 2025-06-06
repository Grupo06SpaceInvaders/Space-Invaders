using UnityEngine;

public class AudioTestController : MonoBehaviour
{
    AudioPlayer audioPlayer;

    private void Start()
    {
        audioPlayer = GetComponent<AudioPlayer>();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            audioPlayer.PlayAudio(0);
        } 
    }
}
