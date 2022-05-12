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
   
    public float contrVelLeft;
    public float contrVelRight;

    [SerializeField] SteamVR_Action_Pose leftPose;
    [SerializeField] SteamVR_Action_Pose rightPose;

    public GameObject newSpawnedL;
    public GameObject newSpawnedR;

    float MinX;
    float MaxX; 
    float MinY;
    float MaxY; 
    float MinZ; 
    float MaxZ;
    float xL;
    float yL;
    float zL;
    float xR;
    float yR;
    float zR;

    private void Start()
    {
        field = FindObjectOfType<FieldSizeManager>().gameObject.GetComponent<FieldSizeManager>();
        pickUpSound = FindObjectOfType<PickUpSound>().gameObject.GetComponent<PickUpSound>();
        spawn = FindObjectOfType<Spawn>().gameObject.GetComponent<Spawn>();
        MinX = -field.radius/2;
        MaxX = field.radius/2;
        MinY = 0.25f;
        MaxY = field.height;
        MinZ = -field.radius/2;
        MaxZ = field.radius;
    }
    public void procideExplosion()
    {

        if (pickUpSound.useingRightHand && pickUpSound.useingLeftHand && pickUpSound.grabbedSound != null)
        {
            exploded = true;
            

            if (newSpawnedL == null)
            {
                xL = Random.Range(MinX, MaxX);
                yL = Random.Range(MinY, MaxY);
                zL = Random.Range(MinZ, MaxZ);

                xR = Random.Range(MinX, MaxX);
                yR = Random.Range(MinY, MaxY);
                zR = Random.Range(MinZ, MaxZ);
                newSpawnedL = Instantiate(spawn.SoundSources[Random.Range(0, spawn.SoundSources.Count)], new Vector3(xL,yL,zL), Quaternion.identity, field.gameObject.transform.parent);
                spawn.currentSounds.Add(newSpawnedL);
               
                if (pickUpSound.grabbedSound != null)
                {
                    newSpawnedR = pickUpSound.grabbedSound;
                    spawn.currentSounds.Remove(pickUpSound.grabbedSound);
                    GameObject anotherNew = Instantiate(pickUpSound.grabbedSound, new Vector3(xR, yR, zR), Quaternion.identity, field.gameObject.transform.parent);
                    spawn.currentSounds.Add(anotherNew);
                    Destroy(pickUpSound.grabbedSound);
                    
                }

                //newSpawnedR = Instantiate(spawn.SoundSources[Random.Range(0, spawn.SoundSources.Count)],new Vector3(xR,yR,zR), Quaternion.identity, field.gameObject.transform.parent);
                //spawn.currentSounds.Add(newSpawnedR);


            }
            //if (pickUpSound.grabbedSound != null)
            //{
            //    spawn.currentSounds.Remove(pickUpSound.grabbedSound);
            //    Destroy(pickUpSound.grabbedSound);
            //}

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

        if (field.inSetup)
        {
            MinX = -field.radius/2;
            MaxX = field.radius/2;
            MinY = 0.25f;
            MaxY = field.height + 0.5f;
            MinZ = -field.radius/2;
            MaxZ = field.radius/2;
        }
    }
}
