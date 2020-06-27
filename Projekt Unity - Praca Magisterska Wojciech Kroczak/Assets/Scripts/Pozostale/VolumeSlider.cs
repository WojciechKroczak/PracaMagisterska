using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    private string volumeValue = "Volume";

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ValueChanged()
    {
        PlayerPrefs.SetFloat(volumeValue, volumeSlider.value);
    }
}
