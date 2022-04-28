using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCrossingDetection : MonoBehaviour
{
    // plan: ein bool wird bei collision auf true gesetzt und bei exit auf false gesetzt. dieser bool wird auf einen generellen manager übertragen, der dann entscheidet welche der collisions am wichtigsten für den Audio Mixer grade ist
    // Start is called before the first frame update

    BorderSounds borderSoundsScr;

    float borderTier;
    void Start()
    {
        borderSoundsScr = GameObject.Find("GeneralBorderAudio").GetComponent<BorderSounds>();

        if (gameObject.tag == "HardBorder")
        {
            borderTier = 3;
        }
        else if (gameObject.tag == "MiddleBorder")
        {
            borderTier = 2;
        }
        else if (gameObject.tag == "SoftBorder")
        {
            borderTier = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // prinzip schwierig, wenn man über
    private void OnTriggerStay(Collider other)
    {

        Debug.Log("collided");
        if (other != borderSoundsScr.head.GetComponent<Collider>()) return;

        if (borderTier == 3)
            borderSoundsScr.inHardBorders = true;
        else if(borderTier == 2)
        {
            borderSoundsScr.inMiddleBorders = true;
        }
        else if (borderTier == 1)
        {
            borderSoundsScr.inSoftBorders = true;
        }

        Debug.Log("head in border");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != borderSoundsScr.head.GetComponent<Collider>()) return;

        if (borderTier == 3)
            borderSoundsScr.inHardBorders = false;
        else if (borderTier == 2)
        {
            borderSoundsScr.inMiddleBorders = false;
        }
        else if (borderTier == 1)
        {
            borderSoundsScr.inSoftBorders = false;
        }
    }

}
