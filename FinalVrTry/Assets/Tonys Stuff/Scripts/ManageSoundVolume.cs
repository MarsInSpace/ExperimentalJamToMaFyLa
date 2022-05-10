using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSoundVolume : MonoBehaviour
{
    [SerializeField] AudioSource thisAudio;
    FieldSizeManager fieldSizeManagerScr;

    MenuButtonManager menubottonmanager;

    Spawn spawnScr;

    BorderSounds BorderSoundsScr;

    bool wasPaused = false;

    public bool inFocus;

    // Start is called before the first frame update
    void Start()
    {
        thisAudio = GetComponent<AudioSource >();
        fieldSizeManagerScr = GameObject.FindGameObjectWithTag("FieldSizeManager").GetComponent<FieldSizeManager>();
        menubottonmanager = GameObject.FindGameObjectWithTag("MenuButtonManager").GetComponent<MenuButtonManager>();
        BorderSoundsScr = GameObject.Find("GeneralBorderAudio").GetComponent<BorderSounds>();
        spawnScr = GameObject.Find("Soundmanager").GetComponent<Spawn>();
    }

    // Update is called once per frame
    void Update()
    {

        if (fieldSizeManagerScr.inSetup || BorderSoundsScr.borderSound.volume == 0.8f || menubottonmanager.InMenu == true)
        {
            thisAudio.Pause();
            wasPaused = true;
        }
        else if(wasPaused)
        {
            wasPaused = false;
            thisAudio.UnPause();
            
        }
        else if(BorderSoundsScr.borderSound.volume == 0.3f)
        {
            thisAudio.volume = 0.25f;
        }
        else if(inFocus)
        {
            thisAudio.volume = 1f;
        }
        else
        {
            thisAudio.volume = 0.5f;
        }

        foreach(var sound in spawnScr.currentSounds)
        {
            if (sound == thisAudio.gameObject) continue;

            ManageSoundVolume soundVolumeScr = sound.GetComponent<ManageSoundVolume>();

            if(soundVolumeScr.inFocus)
            {
                thisAudio.volume = 0f;
            }
        }

        inFocus = false; // muss immer am Ende zurückgesetzt werden, damit die Sounds nicht in Focus bleiben wenn sie nicht mehr fokussiert sind
    }
}
