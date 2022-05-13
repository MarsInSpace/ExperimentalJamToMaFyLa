using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudio : MonoBehaviour
{
    public static RandomAudio instance;
    [SerializeField] Sound[] sound;
    Sound currentSound;
    int index;
    AudioSource source;

    Spawn spawn;

    private void Awake()
    {
        source = this.GetComponent<AudioSource>();

        foreach (Sound s in sound)
        {
            source.clip = s.clip;
            source.volume = s.volume;
            source.pitch = s.pitch;
            source.loop = s.loop;
            source.playOnAwake = s.playOnAwake;
        }

    }

    private void Start()
    {
        spawn = GameObject.Find("Soundmanager").GetComponent<Spawn>();
        ChooseRandomSound();
        Play();
    }


    private void ChooseRandomSound()
    {
        if (spawn.mayhem && this.gameObject.layer == 7)
        {
            index = 0;
            currentSound = sound[index];
        }
        else
        {
            index = Random.Range(0, sound.Length);
            currentSound = sound[index];
        }
    }

    public void Play()
    {
        source.clip = currentSound.clip;
        source.Play();
    }
}

