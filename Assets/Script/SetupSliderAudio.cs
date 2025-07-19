using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupSliderAudio : MonoBehaviour
{
    private AudioManager audioManager;
    public Slider slider;
    private float currentVolume;
    void Start()
    {
        foundAudioManager();
        audioManager.SetupSlider(slider);
        slider.value = audioManager.GetVolume();
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    public void ValueChangeCheck()
    {
        audioManager.SetVolume(slider.value);
        currentVolume = slider.value;
        ApplyVolume();
    }

    public void foundAudioManager() 
    { 
        GameObject foundAudioManager = GameObject.FindGameObjectWithTag("AudioManager");
        audioManager = foundAudioManager.GetComponent<AudioManager>();
    }

    private void ApplyVolume()
    {
        AudioListener.volume = currentVolume;
    }
}
