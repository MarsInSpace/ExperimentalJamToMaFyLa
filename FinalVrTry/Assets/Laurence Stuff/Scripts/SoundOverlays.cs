using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOverlays: MonoBehaviour
{
    public Spawn spawnClass;
    AudioReverbFilter reverb;
    AudioLowPassFilter lowpass;
    public List<GameObject> currentSounds;


    // Start is called before the first frame update
    void Start()
    {
        currentSounds = spawnClass.currentSounds;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            Debug.Log("C gedrueckt");
            CaveEffect();
        }

        if (Input.GetKey(KeyCode.U))
        {
            Debug.Log("U gedrueckt");
            UnderWaterEffect();
        }
    }

    public void UnderWaterEffect()
    {

        foreach (GameObject soundDing in currentSounds)
        {
            lowpass = soundDing.GetComponent<AudioLowPassFilter>();

            lowpass.cutoffFrequency = Mathf.Lerp(5007.7f, 1160, 1);

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
}
