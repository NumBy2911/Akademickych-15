using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("volume", 1f);
        AudioListener.volume = savedVolume;

        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
            volumeSlider.onValueChanged.AddListener(delegate { OnVolumeChanged(); });
        }
    }

    public void OnVolumeChanged()
    {
        AudioListener.volume = volumeSlider.value;

        PlayerPrefs.SetFloat("volume", volumeSlider.value);
        PlayerPrefs.Save();
    }

}
