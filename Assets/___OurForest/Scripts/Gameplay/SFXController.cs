using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SFXController : MonoBehaviour
{
    [SerializeField] AudioMixerGroup Audiomixer;
    [SerializeField] Toggle sfxToggle;
    [SerializeField] Slider sfxSlider;

    void Start()
    {
        FindSource();
    }
    public void FindSource()
    {
        Audiomixer = FindObjectOfType<AudioMixerGroup>();
    }
    private void Update()
    {
        //sfxSlider.value= Audiomixer.audioMixer ;
        Audiomixer.audioMixer.GetFloat("Volume",out float value);
        sfxSlider.value = value;
    }
    public void SetSFXVolume()
    {
        // Audiomixer.volume = sfxSlider.value;
        Audiomixer.audioMixer.SetFloat("Volume", sfxSlider.value);
    }
    public void ToggleSFX()
    {
        if(sfxToggle.isOn==true)
        {
            //audioSource.enabled = false;
            sfxToggle.isOn = false;
        }
        else
        {
          //  audioSource.enabled = false;
            sfxToggle.isOn = false;
        }
    }
}
