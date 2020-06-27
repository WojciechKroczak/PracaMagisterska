using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Srut : MonoBehaviour
{
    public float time = 5.0f;
    private Rigidbody rigid = null;
    public AudioSource _audioSource;
    private string volumeValue = "Volume";
    private float volume;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        SetInactive();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Sound();
        SetInactive();
    }

    public void Launch(Pistolet pistolet)
    {
        transform.position = pistolet.start.position;
        transform.rotation = pistolet.start.rotation;
        gameObject.SetActive(true);
        rigid.AddRelativeForce(Vector3.forward * pistolet.sila, ForceMode.Impulse);
        StartCoroutine(TimeT());
    }

    private IEnumerator TimeT()
    {
        yield return new WaitForSeconds(time);
        SetInactive();
    }

    public void SetInactive()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
        gameObject.SetActive(false);
    }
    private void Sound()
    {
        volume = PlayerPrefs.GetFloat(volumeValue);
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = volume;
        _audioSource.Play();
    }
}
