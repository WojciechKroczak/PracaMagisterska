using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource _audioSource;
    private string volumeValue = "Volume";
    private float volume;

    void Start()
    {
        volume = PlayerPrefs.GetFloat(volumeValue);
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = volume;
        _audioSource.Play();
    }
    

    public void ValueChanged()
    {
        volume = PlayerPrefs.GetFloat(volumeValue);
        _audioSource.volume = volume;
    }
}
