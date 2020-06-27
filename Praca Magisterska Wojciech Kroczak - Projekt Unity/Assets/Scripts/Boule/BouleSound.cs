using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouleSound : MonoBehaviour
{
    public float speed = 1f;
    public float maxSpeed = 5f;
    public AudioSource audioSource;
    public Rigidbody rigidBody;
    public AnimationCurve volumeCurve;
    public AnimationCurve pitchCurve;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        speed = rigidBody.velocity.magnitude;
        var scaledVelocity = Remap(Mathf.Clamp(speed, 0, maxSpeed), 0, maxSpeed, 0, 1);
        audioSource.volume = volumeCurve.Evaluate(scaledVelocity);
        audioSource.pitch = pitchCurve.Evaluate(scaledVelocity);
    }

    public float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
