using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioObject;
    public AudioClip[] audioClips;

   private void Start()
    {
        audioObject = GetComponent<AudioSource>();
    }

    public void PlayAudio(int indice)
    {
        audioObject.clip = audioClips[indice];
        audioObject.Play();
    }
}
