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

    public void DropDownValues()
    {
        if (dropdownvalue == 0)
        {
            fieldsizemanager.radius = 1.5f;
        }

        if (dropdownvalue == 1)
        {
            Debug.Log("value 1 abgefragt");
            fieldsizemanager.radius = 2f;
        }

        if (dropdownvalue == 2)
        {
            fieldsizemanager.radius = 2.5f;
        }

        if (dropdownvalue == 3)
        {
            fieldsizemanager.radius = 3f;
        }
    }
}
