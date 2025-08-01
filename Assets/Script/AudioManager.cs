using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Slider volumeSlider;
    private float currentVolume = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ApplyVolume();
    }

    public void OnVolumeSliderChanged()
    {
        currentVolume = volumeSlider.value;
        ApplyVolume();
    }

    private void ApplyVolume()
    {
        AudioListener.volume = currentVolume;
    }

    public float GetVolume()
    {
        return currentVolume;
    }

    public void SetVolume(float value)
    {
        volumeSlider.value = value;
    }

    public void SetupSlider(Slider _slider)
    {
        volumeSlider = _slider;
    }

}
