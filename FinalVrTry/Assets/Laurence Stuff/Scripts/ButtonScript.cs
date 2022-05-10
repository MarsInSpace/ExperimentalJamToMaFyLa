using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public FieldSizeManager fieldsizemanager;

    public Canvas MenuOverlayStart;

    public void StartTheGame()
    {
        MenuOverlayStart.enabled = false;
        fieldsizemanager.inSetup = true;
    }
}
