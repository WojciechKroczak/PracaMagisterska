using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Zliczanie : MonoBehaviour
{
    List<int> wyniki;

    static string directory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "_PracaMagisterska");
    static string filename = "Strzelectwo.txt";
    string path = Path.Combine(directory, filename);

    void Start()
    {
        wyniki = new List<int>();
    }

    public void Dodaj(int wynik)
    {
        wyniki.Add(wynik);
    }

    public void Zapisz()
    {
        using (var str = new StreamWriter(path))
        {
            foreach (object wyn in wyniki)
            {
                str.WriteLine(wyn);
            }
        str.Flush();
        }
    }
}
