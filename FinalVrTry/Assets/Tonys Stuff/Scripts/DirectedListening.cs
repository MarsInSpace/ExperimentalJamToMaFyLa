using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectedListening : MonoBehaviour
{
    public float rightDistance;
    public float leftDistance;

    public Spawn spawnScr;

    GameObject playerHead;

    public GameObject rightContrl;
    public GameObject leftContrl;

    public bool rightEarListening = false;
    public bool leftEarListening = false;

    public float minDistanceToEar;

    bool stillListening = false;
    bool otherSoundsDisabled = false;


    // Start is called before the first frame update
    void Start()
    {
        playerHead = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(leftEarListening || rightEarListening)
        {
            SendCastToListen();
        }

        ManagePausingOtherSounds();
        ManageUnPausingOtherSounds();
    }

    public void CalculateDistanceToRightContrl()
    {
        rightDistance = Vector3.Distance(playerHead.transform.position, rightContrl.transform.position);
        if (rightDistance <= minDistanceToEar)
        {
            rightEarListening = true;
        }
        else
        {
            rightEarListening = false;
            stillListening = false;
        }
    }


    public void CalculateDistanceToLeftContrl()
    {
        leftDistance = Vector3.Distance(playerHead.transform.position, leftContrl.transform.position);
        if (leftDistance <= minDistanceToEar)
        {
            leftEarListening = true;
        }
        else
        {
            leftEarListening = false;
            stillListening = false;
        }
    }

    void SendCastToListen()
    {
        int directionDetermination;

        if(leftEarListening)
        {
            directionDetermination = -1;
        }
        else
        {
            directionDetermination = 1;
        }

        Debug.DrawRay(playerHead.transform.position, directionDetermination * transform.right);

        RaycastHit hit;

        if (Physics.SphereCast(playerHead.transform.position, .25f, directionDetermination * transform.right, out hit, Mathf.Infinity, ~LayerMask.GetMask("Default")) && (hit.collider.gameObject.layer == 3 || hit.collider.gameObject.layer == 7))
        {
            Debug.Log("spherecast to listen hit something" + hit.collider.gameObject.layer);

            if (stillListening == false)
            {
                Debug.Log("Set sound in focus");
                hit.collider.gameObject.GetComponent<ManageSoundVolume>().inFocus = true;
            }

            stillListening = true;
        }
        else
        {
            stillListening = false;
        }

    }

    void ManagePausingOtherSounds()
    {
        if (!stillListening) return;
        
        if (otherSoundsDisabled) return;

        Debug.Log("Listening, disable other Sounds");
        foreach(var sound in spawnScr.currentSounds)
        {
            ManageSoundVolume volumeScr;
            volumeScr = sound.GetComponent<ManageSoundVolume>();

            if(!volumeScr.inFocus)
            {
                volumeScr.otherSoundInFocus = true;
            }
            else
            {
                volumeScr.otherSoundInFocus = false;
            }
        }

        otherSoundsDisabled = true;
        
    }

    void ManageUnPausingOtherSounds()
    {
        if(!stillListening && otherSoundsDisabled)
        {
            Debug.Log("enable other sounds again");
            foreach (var sound in spawnScr.currentSounds)
            {
                ManageSoundVolume volumeScr;
                volumeScr = sound.GetComponent<ManageSoundVolume>();

                volumeScr.otherSoundInFocus = false;
                volumeScr.inFocus = false;
            }

            otherSoundsDisabled = false;
        }
    }
}
