﻿using System.Collections;
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
        volumeSlider.value = GameManager.Instance.VolumeSliderValue;
    }

    public void SetVolume(float volume)
    {
        GameManager.Instance.VolumeSliderValue = volume;
        audioMixer.SetFloat("Volume", Mathf.Log(volume) * 12);
    }

    private float GetMixerLevel()
    {
        float volume;
        bool result = audioMixer.GetFloat("Volume", out volume);
        return (result) ? volume : 0f;
    }
}
