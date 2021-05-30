using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] Toggle sfxToggle;
    [SerializeField] Slider sfxSlider;

    void Start()
    {
        FindSource();
    }
    public void FindSource()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }
    private void Update()
    {
         sfxSlider.value= audioSource.volume ;
    }
    public void SetSFXVolume()
    {
        audioSource.volume = sfxSlider.value;
    }
    public void ToggleSFX()
    {
        if(sfxToggle.isOn==true)
        {
            audioSource.enabled = false;
            sfxToggle.isOn = false;
        }
        else
        {
            audioSource.enabled = false;
            sfxToggle.isOn = false;
        }
    }
}
