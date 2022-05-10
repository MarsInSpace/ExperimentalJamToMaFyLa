using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Explosion : MonoBehaviour
{
    FieldSizeManager field;
    PickUpSound pickUpSound;
    Spawn spawn;

    float contrDist;
    public float maxDist = 1;
    public float maxVel = 1;
    private bool exploded;

    private bool addedToList;
   
    float contrVelLeft;
    float contrVelRight;

    [SerializeField] SteamVR_Action_Pose leftPose;
    [SerializeField] SteamVR_Action_Pose rightPose;

    public GameObject newSpawnedL;
    public GameObject newSpawnedR;

    Quaternion rot = new Quaternion(0, 0, 0, 0);

    private void Start()
    {
        field = FindObjectOfType<FieldSizeManager>().gameObject.GetComponent<FieldSizeManager>();
        pickUpSound = FindObjectOfType<PickUpSound>().gameObject.GetComponent<PickUpSound>();
        spawn = FindObjectOfType<Spawn>().gameObject.GetComponent<Spawn>();
    }
    public void procideExplosion()
    {
        if (pickUpSound.useingRightHand && pickUpSound.useingLeftHand && pickUpSound.grabbedSound != null)
        {
            exploded = true;

            if (newSpawnedL == null && newSpawnedR == null)
            {
                newSpawnedL = Instantiate(spawn.SoundSources[Random.Range(0, spawn.SoundSources.Count)], leftPose.localPosition, rot, field.gameObject.transform.parent);
                spawn.currentSounds.Add(newSpawnedL);

                newSpawnedR = Instantiate(spawn.SoundSources[Random.Range(0, spawn.SoundSources.Count)], rightPose.localPosition, rot, field.gameObject.transform.parent);
                spawn.currentSounds.Add(newSpawnedR);
            }
            if (pickUpSound.grabbedSound != null)
            {
                spawn.currentSounds.Remove(pickUpSound.grabbedSound);
                Destroy(pickUpSound.grabbedSound);
            }
            
        }
        else
        {
            exploded = false;                  
        }
    }

    private void Update()
    {
        //get velocity
        contrVelLeft = leftPose.velocity.magnitude;
        contrVelRight = rightPose.velocity.magnitude;

        //get distance
        contrDist = Vector3.Distance(pickUpSound.leftContr.transform.position, pickUpSound.rightContr.transform.position);

        //check distance
        if (contrDist >= maxDist)
        {
            //check velocity
            if (contrVelLeft >= maxVel && contrVelRight >= maxVel)
            {
                 procideExplosion();
                
            }
        }
    }
}
