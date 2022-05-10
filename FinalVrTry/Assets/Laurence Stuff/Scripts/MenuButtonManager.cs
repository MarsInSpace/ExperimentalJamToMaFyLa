using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonManager : MonoBehaviour
{
    public FieldSizeManager fieldsizemanager;

    public Canvas MenuOverlayStart;

    public bool InMenu = true;

    int dropdownvalue;

    private void Start()
    {
   
    }

    public void StartTheGame()
    {
        MenuOverlayStart.enabled = false;
        InMenu = false;
        fieldsizemanager.startSetup = true;
    }

    public void MenuToggle()
    {
        if (MenuOverlayStart.enabled == true)
        {
            MenuOverlayStart.enabled = false;
            InMenu = false;
        }
        else
        {
            MenuOverlayStart.enabled = true;
            InMenu = true;
        }
    }


    public void RadiusOne()
    {
        fieldsizemanager.radius = 1.5f;
    }

    public void RadiusTwo()
    {
        fieldsizemanager.radius = 2f;
    }

    public void RadiusThree()
    {
        fieldsizemanager.radius = 2.5f;
    }
}
