using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public AudioClip TriggeredSoundClip;
    AudioSource Audio;

    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Sound"){ //only when player collides
            Audio.clip = TriggeredSoundClip;
            Audio.Play();
        }
    }
}
