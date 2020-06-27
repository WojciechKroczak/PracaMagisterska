using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Valve.VR;

public class ButtonTransitioner : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler,IPointerUpHandler,IPointerClickHandler
{
    public Color32 normalColor = Color.white;
    public Color32 hoverColor = Color.grey;
    public Color32 downColor = Color.red;

    private Image image = null;

    public Canvas MainMenu;
    public Canvas OptionsMenu;
    public Slider volumeSlider;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = normalColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        image.color = downColor;
    }
   
    public void OnPointerUp(PointerEventData eventData)
    {
        image.color = normalColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        image.color = hoverColor;

        if (name == "ButtonPetanque")
        {
            SceneManager.LoadScene("Scenes/Petanque");
        }
        else if (name == "ButtonStrzelectwo")
        {
            SceneManager.LoadScene("Scenes/Shooting");
        }
        else if (name == "ButtonLuk")
        {
            SceneManager.LoadScene("Scenes/BowArrow");
        }
        else if(name == "ButtonUstawienia")
        {
            OptionsMenu.gameObject.SetActive(true);
            MainMenu.gameObject.SetActive(false);
        }
        else if (name == "ButtonUp")
        {
            volumeSlider.value += 0.1f;
        }
        else if (name == "ButtonDown")
        {
            volumeSlider.value -= 0.1f;
        }
        else if (name == "ButtonPowrot")
        {
            MainMenu.gameObject.SetActive(true);
            OptionsMenu.gameObject.SetActive(false);
        }
        else if(name=="ButtonExit")
        {
            Application.Quit();
        }

    }


}
