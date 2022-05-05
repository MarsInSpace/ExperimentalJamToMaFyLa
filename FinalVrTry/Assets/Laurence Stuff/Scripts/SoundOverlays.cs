using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOverlays: MonoBehaviour
{
    public Spawn spawnClass;
    AudioReverbFilter reverb;

    AudioLowPassFilter lowpass;

    AudioSource volumeValue;

    public List<GameObject> currentSounds;

    public Sound currentsound;
    public AudioSource WaterSound;
    public AudioSource FridgeOpenSound;
    public AudioSource IceStormSound;

    public GameObject Playfield;


    // Start is called before the first frame update
    void Start()
    {
        currentSounds = spawnClass.currentSounds;
        

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.C))
        {
            Debug.Log("C gedrueckt");
            CaveEffect();
        }

        if (Input.GetKey(KeyCode.U))
        {
            Debug.Log("U gedrueckt");
            UnderWaterEffect();
        }

        if (Input.GetKey(KeyCode.I))
        {
            Debug.Log("I gedrueckt");
            IceStorm();
        }*/
    }

    public void UnderWaterEffect()
    {
        currentSounds = spawnClass.currentSounds;  // grab sound nicht currentsound

        foreach (GameObject soundDing in currentSounds)
        {

            currentsound = GetComponent<Sound>();

            if (currentsound.name == "Water")

            {
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
