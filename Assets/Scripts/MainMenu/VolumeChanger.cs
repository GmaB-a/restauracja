using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private GameObject volumeText;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
        }
        LoadVolume();
        AudioListener.volume = volumeSlider.value;
        PrintVolume();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        PrintVolume();
        SaveVolume();
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }

    private void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume", volumeSlider.value);
    }

    private void PrintVolume()
    {
        float percent = volumeSlider.value * 100;
        percent = Mathf.Round(percent);
        volumeText.GetComponent<TMP_Text>().text = percent.ToString() + "%";
    }
}
