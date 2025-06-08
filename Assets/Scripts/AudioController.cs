using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider masterSlider, musicSlider, effectsSlider;

    private void Start()
    {
        SavedVolumeSettings();
    }

    public void VolumeController(int indice)
    {
        if (indice == 0) //Set master volume
        {
            mixer.SetFloat("masterVol", masterSlider.value);
            PlayerPrefs.SetFloat("masterVolPrefs", masterSlider.value);
        }
        if(indice == 1) //Set music volume
        {
            mixer.SetFloat("musicVol", musicSlider.value);
            PlayerPrefs.SetFloat("musicVolPrefs", musicSlider.value);
        }
        if (indice == 2) //Set effects volume
        {
            mixer.SetFloat("effectsVol", effectsSlider.value);
            PlayerPrefs.SetFloat("effectsVolPrefs", effectsSlider.value);
        }
        PlayerPrefs.Save(); //Save changes on PlayerPrefs
    }

    private void SavedVolumeSettings()
    {
        mixer.SetFloat("masterVol", PlayerPrefs.GetFloat("masterVolPrefs", 0));
        masterSlider.value = PlayerPrefs.GetFloat("masterVolPrefs", 0);

        mixer.SetFloat("musicVol", PlayerPrefs.GetFloat("musicVolPrefs", 0));
        musicSlider.value = PlayerPrefs.GetFloat("musicVolPrefs", 0);

        mixer.SetFloat("effectsVol", PlayerPrefs.GetFloat("effectsVolPrefs", 0));
        effectsSlider.value = PlayerPrefs.GetFloat("effectsVolPrefs", 0);
    }
}
