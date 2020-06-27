using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CalculateBouleDistance : MonoBehaviour
{
    public GameObject boule1;
    public GameObject boule2;
    public GameObject boule3;
    public GameObject jack;

    static string directory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "_PracaMagisterska");
    static string filename = "Petanque.txt";
    string path = Path.Combine(directory, filename);

    public float distance1, distance2, distance3;

    void Start()
    {
    }

    void Update()
    {

    }

    public void Calculate()
    {
        distance1 = Vector3.Distance(boule1.transform.position, jack.transform.position);
        distance2 = Vector3.Distance(boule2.transform.position, jack.transform.position);
        distance3 = Vector3.Distance(boule3.transform.position, jack.transform.position);

        using (var str = new StreamWriter(path))
        {
            str.WriteLine(distance1);
            str.WriteLine(distance2);
            str.WriteLine(distance3);
            str.Flush();
        }

    }
 
}
