using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLastScene : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void ChangeToLast()
    {
        SceneManager.LoadScene("Scenes/Shooting");
    }
}
