using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underwater : MonoBehaviour
{
    public Spawn spawnClass;
    AudioReverbFilter reverb;
    public List<GameObject> currentSounds;

    // Start is called before the first frame update
    void Start()
    {
        currentSounds = spawnClass.currentSounds;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space gedrueckt");
            UnderWaterEffect();
        }
    }

    public void UnderWaterEffect()
    {

        foreach (GameObject soundDing in currentSounds)
        {
           reverb = soundDing.GetComponent<AudioReverbFilter>();

            reverb.decayTime = 10;
            
        }
    }
}
