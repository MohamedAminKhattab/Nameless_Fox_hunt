using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;
using System;

public class VolumeContol : MonoBehaviour
{
    [SerializeField]
    string _volumeParameter = "MasterVolume";
    [SerializeField]
    AudioMixer _mixer;
    [SerializeField]
    Slider _slider;
    [SerializeField]
    float _multiplier = 30f;
    [SerializeField]
    Toggle _toggle;
    bool _disableToggleEvent;
    void Awake()
    {
        _slider.onValueChanged.AddListener(HandelSliderValueChanged);
        _toggle.onValueChanged.AddListener(HandelToggleValueChanged);
    }
    void Start()
    {
        _slider.value = PlayerPrefs.GetFloat(_volumeParameter, _slider.value);
    }
    void HandelToggleValueChanged(bool enableSound)
    {
        if (_disableToggleEvent)
            return;
        if (enableSound)
            _slider.value = _slider.maxValue;
        else
            _slider.value = _slider.minValue;
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _slider.value);
    }
    void HandelSliderValueChanged(float value)
    {
        _mixer.SetFloat(_volumeParameter, value: Mathf.Log10(value) * _multiplier);
        if (_slider.value < 0.011f)
            _mixer.SetFloat(_volumeParameter, -80);
        _disableToggleEvent = true;
        _toggle.isOn = _slider.value > _slider.minValue;
        _disableToggleEvent = false;
    }
}
