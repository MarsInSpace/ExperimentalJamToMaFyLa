using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSoundVolume : MonoBehaviour
{
    [SerializeField] AudioSource thisAudio;
    FieldSizeManager fieldSizeManagerScr;

    bool wasPaused = false;

    public bool inFocus;

    // Start is called before the first frame update
    void Start()
    {
        thisAudio = GetComponent<AudioSource >();
        fieldSizeManagerScr = GameObject.FindGameObjectWithTag("FieldSizeManager").GetComponent<FieldSizeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fieldSizeManagerScr.inSetup)
        {
            thisAudio.Pause();
            wasPaused = true;
        }
        else if(wasPaused)
        {
            wasPaused = false;
            thisAudio.UnPause();
        }
        else if(inFocus)
        {
            thisAudio.volume = 3f;
        }
        else
        {
            thisAudio.volume = 0.5f;
        }

        inFocus = false; // muss immer am Ende zurückgesetzt werden, damit die Sounds nicht in Focus bleiben wenn sie nicht mehr fokussiert sind
    }
}
