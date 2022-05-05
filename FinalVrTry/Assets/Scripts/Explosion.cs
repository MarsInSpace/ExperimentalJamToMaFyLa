using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Explosion : MonoBehaviour
{
    [SerializeField] FieldSizeManager field;
    [SerializeField] PickUpSound pickUpSound;
    [SerializeField] Spawn spawn;

    public void procideExplosion()
    {
        if (pickUpSound.useingRightHand && pickUpSound.useingLeftHand)
        {
            spawn.currentSounds.Add(Instantiate(spawn.SoundSources[Random.Range(0, spawn.SoundSources.Count)], this.transform.position, new Quaternion(0, 0, 0, 0), field.gameObject.transform.parent));
        }
    }
}
