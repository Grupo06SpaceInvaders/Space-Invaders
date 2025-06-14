using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider masterSlider, musicSlider, effectsSlider;

    private float dB;

    private void Start()
    {
        SavedVolumeSettings();
    }

    public void VolumeController(int indice)
    {
        if (indice == 0) //Set master volume
        {
            mixer.SetFloat("masterVol", Mathf.Log10(masterSlider.value) * 20);
            PlayerPrefs.SetFloat("masterVolPrefs", Mathf.Log10(masterSlider.value) * 20);
        }
        if(indice == 1) //Set music volume
        {
            mixer.SetFloat("musicVol", Mathf.Log10(musicSlider.value) * 20);
            PlayerPrefs.SetFloat("musicVolPrefs", Mathf.Log10(musicSlider.value) * 20);
        }
        if (indice == 2) //Set effects volume
        {
            mixer.SetFloat("effectsVol", Mathf.Log10(effectsSlider.value) * 20);
            PlayerPrefs.SetFloat("effectsVolPrefs", Mathf.Log10(effectsSlider.value) * 20);
        }
        PlayerPrefs.Save(); //Save changes on PlayerPrefs
    }

    private void SavedVolumeSettings()
    {
        mixer.SetFloat("masterVol", PlayerPrefs.GetFloat("masterVolPrefs", 0));
        dB = PlayerPrefs.GetFloat("masterVolPrefs", 0);
        masterSlider.value = Mathf.Pow(10f, dB / 20f);

        mixer.SetFloat("musicVol", PlayerPrefs.GetFloat("musicVolPrefs", 0));
        dB = PlayerPrefs.GetFloat("musicVolPrefs", 0);
        musicSlider.value = Mathf.Pow(10f, dB / 20f);

        mixer.SetFloat("effectsVol", PlayerPrefs.GetFloat("effectsVolPrefs", 0));
        dB = PlayerPrefs.GetFloat("effectsVolPrefs", 0);
        effectsSlider.value = Mathf.Pow(10f, dB / 20f);
    }
}
