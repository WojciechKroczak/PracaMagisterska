using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelLucznictwo : MonoBehaviour
{

    public Color hitColor = Color.white;
    private MeshRenderer meshRender = null;
    private Color originalColor = Color.white;
    public GameObject tarcza;

    private void Awake()
    {
        meshRender = GetComponent<MeshRenderer>();
        originalColor = meshRender.material.color;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            Hit();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            Hit();
        }
    }


    private void Hit()
    {
        StopAllCoroutines();
        StartCoroutine(Flash());
        Zliczenie zliczanie = tarcza.GetComponent<Zliczenie>();

        int value = Int16.Parse(this.name);
        zliczanie.Dodaj(value);
    }

    private IEnumerator Flash()
    {
        meshRender.material.color = hitColor;
        WaitForSeconds wait = new WaitForSeconds(0.1f);
        yield return wait;
        meshRender.material.color = originalColor;
    }


}
