using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelStrzelctwo : MonoBehaviour
{
    public Color hitColor = Color.white;
    private Color originalColor = Color.white;
    private MeshRenderer meshRender = null;
    public GameObject kulochwyt;
    private void Awake()
    {
        meshRender = GetComponent<MeshRenderer>();
        originalColor = meshRender.material.color;
    }

    private void OnEnable()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Damage();
        }
    }

    private void Damage()
    {
        StopAllCoroutines();
        StartCoroutine(Flash());
        Zliczanie zliczanie = kulochwyt.GetComponent<Zliczanie>();
       
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
