using System.Collections;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrow = null;

    public float grabM = 0.15f;
    public Transform _start = null;
    public Transform _end = null;
    public Transform notch = null;
    public AudioSource _audioSource;

    private Transform pullingHand = null;
    private float pullS = 0.0f;
    private Arrow currentArrow = null;
    private Animator anim = null;
    private string volumeValue = "Volume";
    private float volume;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(CreateArrow(0.0f));
    }

    private void Update()
    {
        if(!pullingHand || !currentArrow)
        {
            return;
        }
        pullS = CalculatePull(pullingHand);
        pullS = Mathf.Clamp(pullS, 0.0f, 1.0f);
        anim.SetFloat("Blend", pullS);
    }

    private float CalculatePull(Transform pullHand)
    {
        Vector3 direction = _end.position - _start.position;
        float magnitude = direction.magnitude;
        direction.Normalize();
        Vector3 difference = pullHand.position - _start.position;
        return Vector3.Dot(difference,direction)/magnitude;
    }

    private IEnumerator CreateArrow(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject arrowObject = Instantiate(arrow, notch);
        arrowObject.transform.localPosition = new Vector3(0, 0, 0.425f);
        arrowObject.transform.localEulerAngles = Vector3.zero;
        currentArrow = arrowObject.GetComponent<Arrow>();
    }

    public void Pull(Transform hand)
    {
        float distance = Vector3.Distance(hand.position, _start.position);
        if(distance > grabM)
        {
            return;
        }
        pullingHand = hand;
    }

    public void Release()
    {
        if (pullS > 0.25f)
        {
            Fire();
            BowSound();
        }
        pullingHand = null;
        pullS = 0.0f;
        anim.SetFloat("Blend", 0);
        if (!currentArrow)
        {
            StartCoroutine(CreateArrow(0.25f));
        }
    }

    private void Fire()
    {
        currentArrow.Fire(pullS);
        currentArrow = null;
    }

    private void BowSound()
    {
        volume = PlayerPrefs.GetFloat(volumeValue);
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = volume;
        _audioSource.Play();
    }
}
