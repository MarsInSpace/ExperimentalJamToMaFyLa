using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteSound : MonoBehaviour
{
    [SerializeField] AudioSource thisAudio;
    FieldSizeManager fieldSizeManagerScr;

    bool wasPaused = false;

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
    }
}
