using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class VFXController : MonoBehaviour
{
    [SerializeField] AudioManager am;
    [SerializeField] Sound bgm;
    [SerializeField] Toggle vfxToggle;
    [SerializeField] Slider vfxSlider;
    void Start()
    {
        am = FindObjectOfType<AudioManager>();
        bgm = am.GetComponentsInChildren<Sound>().ToList().ElementAt<Sound>(0);
    }
    private void Update()
    {
         vfxSlider.value= bgm.volume ;
    }
    public void SetVFXVolume()
    {
        bgm.volume = vfxSlider.value;
    }
    public void ToggleVFX()
    {
        if (vfxToggle.isOn == true)
        {
            bgm.source.enabled = false;
            vfxToggle.isOn = false;
        }
        else
        {
            bgm.source.enabled = false;
            vfxToggle.isOn = false;
        }
    }
}
