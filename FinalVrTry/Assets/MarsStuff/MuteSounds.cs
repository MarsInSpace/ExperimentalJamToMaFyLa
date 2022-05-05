using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteSounds : MonoBehaviour
{
    public BorderSounds BorderSoundsScr;
    AudioSource thisAudio;
    // Start is called before the first frame update
    void Start()
    {
        BorderSoundsScr = GameObject.Find("GeneralBorderAudio").GetComponent<BorderSounds>();
        thisAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BorderSoundsScr.borderSound.volume == 0.8f){
            thisAudio.volume = 0.5f;
        }
        else if (BorderSoundsScr.borderSound.volume == 0 || BorderSoundsScr.borderSound.volume == 0.3f){
            thisAudio.mute = true;
        }
        else{
            thisAudio.mute = false;
            thisAudio.volume = 1;
        }
    }
}
