using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour
{
    float lifeSpan = 4f;
    float deathTime;

    AudioSource thisAudio;

    bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        DetermineDeath();

        thisAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!started)
        {
            started = true;
            Debug.Log("Start Audio");
            thisAudio.Play();
        }


        if(Time.time >= deathTime)
        {
            Debug.Log("destroy death sound");
            Destroy(gameObject);
        }
    }

    void DetermineDeath()
    {
        deathTime = Time.time + lifeSpan;
    }
}
