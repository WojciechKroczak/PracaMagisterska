using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour
{
    public float length = 5.0f;
    public GameObject sphere;
    public VRInputModule input;

    private LineRenderer lineRenderer = null;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        PointerEventData data = input.GetData();
        float target;

        if (data.pointerCurrentRaycast.distance == 0)
        {
            target = length;
        }
        else
        {
            target = data.pointerCurrentRaycast.distance;
        }

        RaycastHit hit = CreateRaycast(target);
        Vector3 end = transform.position + (transform.forward* target);

        if (hit.collider != null)
        {
            end = hit.point;
        }

        sphere.transform.position = end;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, end);
        
    }

    private RaycastHit CreateRaycast(float _length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray,out hit, length);
        return hit;
    }
}
