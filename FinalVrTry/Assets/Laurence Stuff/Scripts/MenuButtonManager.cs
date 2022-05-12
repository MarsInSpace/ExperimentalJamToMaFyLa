using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonManager : MonoBehaviour
{
    public FieldSizeManager fieldsizemanager;
    public CameraBlack cameraBlack;

    public Canvas MenuOverlayStart;

    public Canvas MenuOverlayPause;

    public bool InMenu = true;


    private void Start()
    {
   
    }


   private void Update()
    {
        if (InMenu == true)
            cameraBlack.CameraCullingMenu();
        else
            cameraBlack.CameraCullingNothing();
    }

    public void StartTheGame()
    {
        MenuOverlayStart.enabled = false;
        InMenu = false;
        fieldsizemanager.startSetup = true;
    }

    public void MenuToggle()
    {
        if (MenuOverlayPause.enabled == true)
        {
            MenuOverlayPause.enabled = false;
            InMenu = false;
        }
        else
        {
            MenuOverlayPause.enabled = true;
            InMenu = true;
        }
    }

    public void ContinueGame()
    {
        MenuOverlayPause.enabled = false;
        InMenu = false;
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
