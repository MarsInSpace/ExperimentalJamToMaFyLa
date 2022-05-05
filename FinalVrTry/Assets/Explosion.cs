using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Explosion : MonoBehaviour
{
    [SerializeField] PickUpSound pickUpSound;
    [SerializeField] Spawn spawn;


    private void Update()
    {
        if(pickUpSound.useingRightHand && pickUpSound.useingLeftHand)
        {
            procideExplosion();
        }    
    }

    private void procideExplosion()
    {
        spawn.currentSounds.Add(Instantiate(spawn.SoundSources[Random.Range(0, spawn.SoundSources.Count)], this.transform.position, new Quaternion(0, 0, 0, 0)));
    }
}
