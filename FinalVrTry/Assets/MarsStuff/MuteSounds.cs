using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteSounds : MonoBehaviour
{
    BorderSounds BorderScript;
    float BorderLevel;
    AudioSource Audio;
    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        BorderLevel = BorderScript.borderTier;
    }

    // Update is called once per frame
    void Update()
    {
        BorderLevel = BorderScript.borderTier;

        if (BorderLevel == 1){
            Audio.volume = 0.5f;
        }
        else if (BorderLevel == 2 || BorderLevel == 3){
            Audio.mute = true;
        }
        else{
            Audio.mute = false;
            Audio.volume = 1;
        }
    }
}
