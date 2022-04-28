using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR; // das ist die wichtige using Directive

public class BorderSounds : MonoBehaviour
{
    // neuer Plan: wir messen vom Mittelpunkt aus den Abstand

    public FieldSizeManager fieldSizeManagerScr;

    public GameObject fieldFloor;

    float playerHeight;

    public float distanceToMiddle;

    float fieldRadius;
    float lastFieldRadius;

    public AudioSource borderSound;
    public GameObject playerHead;

    public float hardBorderMargin;
    public float softBorderMargin;

    float hardBorder;
    float softBorder;

    private void Update()
    {
        playerHeight = fieldSizeManagerScr.height;
        fieldRadius = fieldSizeManagerScr.radius;

        ManageResettingRadius();

        MeasureDistance();

        ManageVolume();
    }

    void ManageVolume()
    {
        if (distanceToMiddle >= hardBorder)
        {
            borderSound.volume = 1;
        }
        else if (distanceToMiddle >= softBorder)
        {
            borderSound.volume = 0.3f;
        }
        else
        {
            borderSound.volume = 0f;
        }
    }

    void MeasureDistance()
    {
        distanceToMiddle = Vector3.Distance(playerHead.transform.position, new Vector3(fieldFloor.transform.position.x, playerHeight, fieldFloor.transform.position.z));
        Debug.DrawLine(playerHead.transform.position, new Vector3(fieldFloor.transform.position.x, playerHeight, fieldFloor.transform.position.z));
    }

    void ManageResettingRadius()
    {
        if(lastFieldRadius != fieldRadius)
        {
            DetermineSoundBorder();
        }
        lastFieldRadius = fieldRadius;
    }

    void DetermineSoundBorder()
    {
        hardBorder = fieldRadius - hardBorderMargin;
        softBorder = fieldRadius - softBorderMargin;
    }


    /*//Plan: wir machen drei collider, die eine Abstufung an Sounddistortion sind. Das wird dann alles von einem Script gemanaged -> vielleicht dumm
    /*public Collider[] bordersSoft;
    public Collider[] bordersMiddle;
    public Collider[] bordersHard;*/

    //float bordertier;
    /*
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
    }*/
}
