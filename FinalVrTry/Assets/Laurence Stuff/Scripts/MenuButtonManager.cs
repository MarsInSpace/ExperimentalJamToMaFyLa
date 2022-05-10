using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonManager : MonoBehaviour
{
    public FieldSizeManager fieldsizemanager;

    public Canvas MenuOverlayStart;

    public bool InMenu = true;

    public void StartTheGame()
    {
        MenuOverlayStart.enabled = false;
        fieldsizemanager.startSetup = true;
        InMenu = false;
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
}
