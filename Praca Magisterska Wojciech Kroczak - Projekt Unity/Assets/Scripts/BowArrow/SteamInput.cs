using UnityEngine;
using Valve.VR;

public class SteamInput : MonoBehaviour
{
    public Bow bow = null;
    public SteamVR_Behaviour_Pose pose = null;
    public SteamVR_Action_Boolean action = null;

    private void Update()
    {

        if (action.GetStateDown(pose.inputSource))
        {
            bow.Pull(pose.gameObject.transform);
        }
           
        if (action.GetStateUp(pose.inputSource))
        {
            bow.Release();
        }         
    }
    
}
