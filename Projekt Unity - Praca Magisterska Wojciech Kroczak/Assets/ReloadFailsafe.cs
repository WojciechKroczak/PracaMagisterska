using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class ReloadFailsafe : MonoBehaviour
{
    public SteamVR_Action_Boolean reloadGrip = null;
    private SteamVR_Behaviour_Pose pose = null;
    void Start()
    {
        pose = GetComponentInParent<SteamVR_Behaviour_Pose>();
    }

    void Update()
    {
        if (reloadGrip.GetStateDown(pose.inputSource))
        {
            Reload();
        }
    }

    private void Reload()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}
