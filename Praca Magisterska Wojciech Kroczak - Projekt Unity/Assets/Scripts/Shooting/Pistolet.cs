using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Pistolet : MonoBehaviour
{
    public SteamVR_Action_Boolean _fire = null;
    public SteamVR_Action_Boolean _reload = null;
    public float sila = 0.1f;
    public int maxSrut = 10;
    public float resetMagazine = 3f;
    public Transform start = null;
    public GameObject srutPrefab = null;
    public Text infoText = null;

    private bool isReloading = false;
    private int fired = 0;
    private SteamVR_Behaviour_Pose _pose = null;
    private PociskiMagazynek _magazynek = null;
    public AudioSource _audioSource;
    private string volumeValue = "Volume";
    private float volume;

    private void Awake()
    {
        _pose = GetComponentInParent<SteamVR_Behaviour_Pose>();
        _magazynek = new PociskiMagazynek(srutPrefab, maxSrut);
    }

    private void Start()
    {
        Fired(0);
    }

    private void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (_fire.GetStateDown(_pose.inputSource))
        {
            Fire();
        }
        if (_reload.GetStateDown(_pose.inputSource))
        {
            StartCoroutine(Reload());
        }

    }

    private void Fire()
    {
        if (fired >= maxSrut)
        {
            return;
        }
        Sound();
        Srut targetProjectile = _magazynek.m_Srut[fired];
        targetProjectile.Launch(this);
        Fired(fired+1);
    }

    private IEnumerator Reload()
    {
        if (fired == 0)
        {
            yield break;
        }
        infoText.text = "-";
        isReloading = true;
        _magazynek.SetAllSrut();
        yield return new WaitForSeconds(resetMagazine);
        Fired(0);
        isReloading = false;
    }

    private void Fired(int newValue)
    {
        fired = newValue;
        infoText.text = (maxSrut-fired).ToString();
    }

    private void Sound()
    {
        volume = PlayerPrefs.GetFloat(volumeValue);
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = volume;
        _audioSource.Play();
    }

}
