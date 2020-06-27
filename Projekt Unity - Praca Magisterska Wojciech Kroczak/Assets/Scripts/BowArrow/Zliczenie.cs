using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Zliczenie : MonoBehaviour
{
    List<int> wyniki;
    List<int> wystrzaly;

    static string directory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "_PracaMagisterska");
    static string filename = "Lucznictwo.txt";
    string path = Path.Combine(directory, filename);

    void Start()
    {
        wyniki = new List<int>();
        wystrzaly = new List<int>();
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
            str.WriteLine("Ilosc wystrzalow:");
            int sumaStrzal = wystrzaly.Sum(x => Convert.ToInt32(x));
            str.WriteLine(sumaStrzal);
            str.Flush();
        }

    }

    public void DodajWystrzal()
    {
        wystrzaly.Add(1);
    }
}
