using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class VRInputModule : BaseInputModule
{

    public Camera camera;
    public SteamVR_Input_Sources source;
    public SteamVR_Action_Boolean click;

    private GameObject current = null;
    private PointerEventData eventS = null;

    protected override void Awake()
    {
        base.Awake();

        eventS = new PointerEventData(eventSystem);
    }


    public override void Process()
    {
        eventS.Reset();
        eventS.position = new Vector2(camera.pixelWidth/2, camera.pixelHeight/2);

        eventSystem.RaycastAll(eventS, m_RaycastResultCache);
        eventS.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        current = eventS.pointerCurrentRaycast.gameObject;

        m_RaycastResultCache.Clear();

        HandlePointerExitAndEnter(eventS, current);

        if (click.GetStateDown(source))
        {
            ProcessPress(eventS);
        }

        if (click.GetStateUp(source))
        {
            ProcessRelease(eventS);
        }
    }

    public PointerEventData GetData()
    {
        return eventS;
    }

    private void ProcessPress(PointerEventData data)
    {
        data.pointerPressRaycast = data.pointerCurrentRaycast;
        GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(current, data, ExecuteEvents.pointerDownHandler);
        if (newPointerPress == null)
        {
            newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(current);
        }
        data.pressPosition = data.position;
        data.pointerPress = newPointerPress;
        data.rawPointerPress = current;
    }

    private void ProcessRelease(PointerEventData data)
    {
        ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);
        GameObject pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(current);
        if (data.pointerPress == pointerUpHandler)
        {
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
        }
        eventSystem.SetSelectedGameObject(null);
        data.pressPosition = Vector2.zero;
        data.pointerPress = null;
        data.rawPointerPress = null;
    }

}
