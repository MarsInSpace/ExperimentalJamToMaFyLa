using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOverlays: MonoBehaviour
{
    public Spawn spawnClass;
    public PickUpSound pickUpSound;

    AudioReverbFilter reverb;

    AudioLowPassFilter lowpass;

    AudioSource volumeValue;

    public List<GameObject> currentSounds;

    //public Sound currentsound;
    public AudioSource WaterSound;
    public AudioSource IceStormSound;
    public AudioSource FridgeDoorOpenSound;
    public AudioSource FridgeDoorCloseSound;
    public AudioSource ChoirSound;

    public GameObject Playfield;

    public GameObject grabbedSound;

    bool iceStormRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        currentSounds = spawnClass.currentSounds;
        
    }




    // Update is called once per frame
    void Update()
    {
        currentSounds = spawnClass.currentSounds;

        if (WaterSound.isPlaying) Debug.Log("Water playing");
        if (IceStormSound.isPlaying) Debug.Log("ice playing");
        if (ChoirSound.isPlaying) Debug.Log("choir playing");
        UnderWaterEffectOFF();
        IceStormEffectOFF();
        HallEffectOFF();
    }


    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    public void UnderWaterEffectL()
    {
        ApplyUnderWaterEffect(pickUpSound.grabbedL);
    }
    public void UnderWaterEffectR()
    {
        ApplyUnderWaterEffect(pickUpSound.grabbedR);
    }



    public void IceStromEffectL()
    {
        IceStorm(pickUpSound.grabbedL);
    }

    public void IceStromEffectR()
    {
        IceStorm(pickUpSound.grabbedR);
    }



    public void HallEffectL()
    {
        ApplyHallEffect(pickUpSound.grabbedL);
    }

    public void HallEffectR()
    {
        ApplyHallEffect(pickUpSound.grabbedR);
    }



    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////





    public void UnderWaterEffectOFF()
    {
        if ((pickUpSound.grabbedL == null || pickUpSound.grabbedL.name != "Wasser(Clone)") && (pickUpSound.grabbedR == null || pickUpSound.grabbedR.name != "Wasser(Clone)"))
        {
            foreach (GameObject soundDing in currentSounds)
            {
                //Debug.Log("Name Wasser wird erkannt");
                lowpass = soundDing.GetComponent<AudioLowPassFilter>();

                lowpass.cutoffFrequency = Mathf.Lerp(1160, 5007.7f, 1);

                reverb = soundDing.GetComponent<AudioReverbFilter>();

                reverb.decayTime = Mathf.Lerp(2, 1, 1);

                WaterSound.Stop();
            }
        }
    }


    void ApplyUnderWaterEffect(GameObject grabbedSound)
    {
        //Debug.Log("Effect wird gecalled");
        //grabbedSound = GetComponent<GameObject>();
        if (grabbedSound != null && grabbedSound.name == "Wasser(Clone)")
        {
                //Debug.Log("If abfrage wird gemacht");

            foreach (GameObject soundDing in currentSounds)
            {
                //Debug.Log("Name Wasser wird erkannt");
                lowpass = soundDing.GetComponent<AudioLowPassFilter>();

                lowpass.cutoffFrequency = Mathf.Lerp(5007.7f, 1160, 1);

                reverb = soundDing.GetComponent<AudioReverbFilter>();

                reverb.decayTime = Mathf.Lerp(1, 2, 1);

            }
            WaterSound.Play();
        }
    }




    ////////////////////////////////////////////////////////////////////////////////////////////////////





    public void IceStorm(GameObject grabbedSound)
    {

        if (grabbedSound != null && grabbedSound.name == "Kühlschrank(Clone)" && !iceStormRunning)
        {
            iceStormRunning = true;
            StartCoroutine(WaitFiveSeconds());
        }
    }

    public void IceStormEffectOFF()
    {
        if (iceStormRunning &&((pickUpSound.grabbedL == null || pickUpSound.grabbedL.name != "Kühlschrank(Clone)") && (pickUpSound.grabbedR == null || pickUpSound.grabbedR.name != "Kühlschrank(Clone)")))
        {
            iceStormRunning = false;
            FridgeDoorCloseSound.Play();
            
            foreach (GameObject soundDing in currentSounds)
            {
 
                lowpass = soundDing.GetComponent<AudioLowPassFilter>();
                lowpass.cutoffFrequency = Mathf.Lerp(2000, 5007.7f, 1);

            }
            IceStormSound.Stop();
            Debug.Log("stop ice");
        }
    }
    IEnumerator WaitFiveSeconds()
    {
        if (!FridgeDoorOpenSound.isActiveAndEnabled) Debug.Log("fridge disabled");
        FridgeDoorOpenSound.Play();
        Debug.Log("play fridge");
        foreach (GameObject soundDing in currentSounds)
        {
            lowpass = soundDing.GetComponent<AudioLowPassFilter>();
            lowpass.cutoffFrequency = Mathf.Lerp(5007.7f, 2000, 1);
            Debug.Log("change audio properties for " + soundDing);
        }
        IceStormSound.Play();
        Debug.Log("start ice");
        yield return new WaitForSeconds(1);
    }




    //////////////////////////////////////////////////////////////////////////////////////////////////////




    public void ApplyHallEffect(GameObject grabbedSound)
    {
        if (grabbedSound != null && grabbedSound.name == "Door(Clone)")
        {
            foreach (GameObject soundDing in currentSounds)
            {

                reverb = soundDing.GetComponent<AudioReverbFilter>();
                reverb.decayTime = Mathf.Lerp(1, 8, 1);

            }
            ChoirSound.Play();
        }
    }


    public void HallEffectOFF()
    {
        if ((pickUpSound.grabbedL == null || pickUpSound.grabbedL.name != "Doors(Clone)") && (pickUpSound.grabbedR == null || pickUpSound.grabbedR.name != "Doors(Clone)"))
        {
            foreach (GameObject soundDing in currentSounds)
            { 
                reverb = soundDing.GetComponent<AudioReverbFilter>();

                reverb.decayTime = Mathf.Lerp(8, 1, 1);

                ChoirSound.Stop();
            }
        }
    }

}
