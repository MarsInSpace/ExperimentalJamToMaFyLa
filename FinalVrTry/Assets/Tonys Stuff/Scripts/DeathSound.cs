using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour
{
    float lifeSpan = 3f;
    float deathTime;

    // Start is called before the first frame update
    void Start()
    {
        DetermineDeath();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= deathTime)
        {
            Destroy(gameObject);
        }
    }

    void DetermineDeath()
    {
        deathTime = Time.time + lifeSpan;
    }
}
