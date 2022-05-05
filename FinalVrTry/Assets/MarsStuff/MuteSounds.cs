using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteSounds : MonoBehaviour
{
    public BorderSounds BorderScript;
    AudioSource Audio;
    // Start is called before the first frame update
    void Start()
    {
        BorderScript = GameObject.Find("GeneralBorderAudio").GetComponent<BorderSounds>();
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BorderScript.borderSound.volume == 0.8f){
            Audio.volume = 0.5f;
        }
        else if (BorderScript.borderSound.volume == 0 || BorderScript.borderSound.volume == 0.3f){
            Audio.mute = true;
        }
        else{
            Audio.mute = false;
            Audio.volume = 1;
        }
    }
}
