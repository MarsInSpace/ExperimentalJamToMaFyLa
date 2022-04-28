using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR; // das ist die wichtige using Directive

public class BorderSounds : MonoBehaviour
{
    //Plan: wir machen drei collider, die eine Abstufung an Sounddistortion sind. Das wird dann alles von einem Script gemanaged -> vielleicht dumm
    /*public Collider[] bordersSoft;
    public Collider[] bordersMiddle;
    public Collider[] bordersHard;*/

    //float bordertier;

    public InputDevice headSet;

    public GameObject head;

    public AudioSource borderSound;

    public bool inHardBorders;
    public bool inMiddleBorders;
    public bool inSoftBorders;

    public Camera currentlyUsedCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TrackHeadSet();

        ManageVolume();
    }

    void TrackHeadSet() // die main camera ist zufällig genau da
    {
        head.transform.position = currentlyUsedCamera.transform.position;
    }

    void ManageVolume()
    {
        if (inHardBorders)
        {
            borderSound.volume = 1;
        }
        else if (inMiddleBorders)
        {
            borderSound.volume = 0.4f;
        }
        else if (inSoftBorders)
        {
            borderSound.volume = 0.1f;
        }
        else
        {
            borderSound.volume = 0f;
        }
    }
}
