using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Explosion : MonoBehaviour
{
    [SerializeField] FieldSizeManager field;
    [SerializeField] PickUpSound pickUpSound;
    [SerializeField] Spawn spawn;
    float contrDist;
    public float maxDist = 1;
    public float maxVel = 1;
    public bool exploded;
   
    Vector3 contrVelLeft;
    Vector3 contrVelRight;

    [SerializeField] SteamVR_Action_Pose leftPose;
    [SerializeField] SteamVR_Action_Pose rightPose;

    public GameObject newSpawnedL;
    public GameObject newSpawnedR;

    public void procideExplosion()
    {
        if (pickUpSound.useingRightHand && pickUpSound.useingLeftHand)
        {
            Debug.Log("useing both hands");
            exploded = true;

            if (newSpawnedL == null && newSpawnedR == null)
            {
                newSpawnedL = Instantiate(spawn.SoundSources[Random.Range(0, spawn.SoundSources.Count)], this.transform.position, new Quaternion(0, 0, 0, 0), field.gameObject.transform.parent);
                spawn.currentSounds.Add(newSpawnedL);

                newSpawnedR = Instantiate(spawn.SoundSources[Random.Range(0, spawn.SoundSources.Count)], this.transform.position, new Quaternion(0, 0, 0, 0), field.gameObject.transform.parent);
                spawn.currentSounds.Add(newSpawnedR);
            }
            spawn.currentSounds.Remove(pickUpSound.grabbedSound);
            Destroy(pickUpSound.grabbedSound);
            
        }
        else
        {
            exploded = false;                  
        }
    }

    private void Update()
    {
        contrVelLeft = leftPose.velocity;
        contrVelRight = rightPose.velocity;

        contrDist = Vector3.Distance(pickUpSound.leftContr.transform.position, pickUpSound.rightContr.transform.position);
        if (contrDist >= maxDist)
        {
            Debug.Log("Distanced");
            if(contrVelLeft.x >= maxVel || contrVelLeft.z >= maxVel || contrVelLeft.y >= maxVel)
            {
                if (contrVelRight.x >= maxVel || contrVelRight.z >= maxVel || contrVelRight.y >= maxVel)
                {
                    Debug.Log("Velocetied");
                    procideExplosion();
                }
            }           
        }
    }
}
