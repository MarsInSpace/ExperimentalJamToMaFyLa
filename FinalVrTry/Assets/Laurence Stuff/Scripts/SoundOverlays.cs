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
    public AudioSource FridgeOpenSound;
    public AudioSource IceStormSound;

    public GameObject Playfield;

    public GameObject grabbedSound;



    // Start is called before the first frame update
    void Start()
    {
        currentSounds = spawnClass.currentSounds;
        

    }

    // Update is called once per frame
    void Update()
    {
        UnderWaterEffectOFF();
    }

    public void UnderWaterEffectL()
    {
        ApplyEffect(pickUpSound.grabbedL);
    }
    public void UnderWaterEffectR()
    {
        ApplyEffect(pickUpSound.grabbedR);
    }

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


    void ApplyEffect(GameObject grabbedSound)
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

                WaterSound.Play();
            }
        }
    }


    public void CaveEffect()
    {

        foreach (GameObject soundDing in currentSounds)
        {
            reverb = soundDing.GetComponent<AudioReverbFilter>();

            reverb.decayTime = Mathf.Lerp(1, 7, 1);

        }
    }


    public void IceStorm()
    {
        StartCoroutine(OpenDoorAndIce());

    }

    IEnumerator OpenDoorAndIce()
    {
        foreach (GameObject soundDing in currentSounds)
        {
            volumeValue = soundDing.GetComponent<AudioSource>();
            volumeValue.volume = 0.5f;

        }

        FridgeOpenSound.Play();
        yield return new WaitForSeconds(0.5f);
   
        foreach (GameObject soundDing in currentSounds)
        {
            lowpass = soundDing.GetComponent<AudioLowPassFilter>();
            lowpass.cutoffFrequency = Mathf.Lerp(5007.7f, 2000, 1);

            volumeValue = soundDing.GetComponent<AudioSource>();
            volumeValue.volume = 1;
        }
        IceStormSound.Play();

    } 

}
