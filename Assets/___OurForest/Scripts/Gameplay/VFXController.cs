using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VFXController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] Toggle vfxToggle;
    [SerializeField] Slider vfxSlider;
    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }
    private void Update()
    {
         vfxSlider.value= audioSource.volume ;
    }
    public void SetVFXVolume()
    {
          audioSource.volume= vfxSlider.value;
    }
    public void ToggleVFX()
    {
        if (vfxToggle.isOn == true)
        {
            audioSource.enabled = false;
            vfxToggle.isOn = false;
        }
        else
        {
            audioSource.enabled = false;
            vfxToggle.isOn = false;
        }
    }
}
