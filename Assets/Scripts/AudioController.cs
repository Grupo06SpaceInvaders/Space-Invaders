using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider masterSlider, musicSlider, effectsSlider;

    public void VolumeController(int indice)
    {
        if (indice == 0)
        {
            mixer.SetFloat("masterVol", masterSlider.value);
        }
        if(indice == 1)
        {
            mixer.SetFloat("musicVol", musicSlider.value);
        }
        if (indice == 2)
        {
            mixer.SetFloat("effectsVol", effectsSlider.value);
        }
    }
}
