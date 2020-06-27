using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazynek : MonoBehaviour
{
    public List<T> Create<T>(GameObject prefab, int count) where T : MonoBehaviour
    {
        List<T> magazynek = new List<T>();
        for (int i = 0; i < count; i++)
        {
            GameObject srut = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
            T _srut = srut.GetComponent<T>();

            magazynek.Add(_srut);
        }

        return magazynek;
    }
}

public class PociskiMagazynek : Magazynek
{
    public List<Srut> m_Srut= new List<Srut>();

    public PociskiMagazynek(GameObject prefab, int count)
    {
        m_Srut = Create<Srut>(prefab, count);
    }

    public void SetAllSrut()
    {
        foreach (Srut srut in m_Srut)
        {
            srut.SetInactive();
        }
    }
}
