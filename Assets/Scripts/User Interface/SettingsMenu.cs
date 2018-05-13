using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour 
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        volumeSlider.value = GetMixerLevel();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    private float GetMixerLevel()
    {
        float volume;
        bool result = audioMixer.GetFloat("Volume", out volume);
        return (result) ? volume : 0f;
    }
}
