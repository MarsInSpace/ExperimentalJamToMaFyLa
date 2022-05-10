using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PickUpSound : MonoBehaviour
{
    Explosion explosion;
    public bool useingLeftHand =false;
    public bool useingRightHand = false;

    public float distToPickUp = 0.5f;
   
    public LayerMask pickUpLayer;

    [SerializeField] public SteamVR_Behaviour_Pose leftContr;
    [SerializeField] public SteamVR_Behaviour_Pose rightContr;

    [HideInInspector]
    public GameObject grabbedSound;

    public GameObject grabbedL;
    public GameObject grabbedR;

    [SerializeField] Rigidbody holdingTargetR;
    [SerializeField] Rigidbody holdingTargetL;

    private void Start()
    {
        explosion = FindObjectOfType<Explosion>().gameObject.GetComponent<Explosion>();
    }

    private void Update()
    {
        CompareSounds();
    }

    public void GrabbedLeft()
    {
        if (holdingTargetL == null)
        {
            Collider[] colliders = Physics.OverlapSphere(leftContr.transform.position, distToPickUp, pickUpLayer);
            if (colliders.Length > 0)
            {
                holdingTargetL = colliders[0].gameObject.GetComponent<Rigidbody>();
                grabbedL = colliders[0].gameObject;
            }
        }
        else
        {
            holdingTargetL.velocity = (leftContr.transform.position - holdingTargetL.transform.position) / Time.fixedDeltaTime;
            holdingTargetL.maxAngularVelocity = 15;
        }
            useingLeftHand = true;
        
    }
    public void GrabbedRight()
    {
        if (holdingTargetR == null)
        {
            Collider[] colliders = Physics.OverlapSphere(rightContr.transform.position, distToPickUp, pickUpLayer);
            if (colliders.Length > 0)
            {
                holdingTargetR = colliders[0].gameObject.GetComponent<Rigidbody>();
                grabbedR = colliders[0].gameObject;
            }
        }
        else
        {
            holdingTargetR.velocity = (rightContr.transform.position - holdingTargetR.transform.position) / Time.fixedDeltaTime;
            holdingTargetR.maxAngularVelocity = 15;
        }
        useingRightHand = true;
    }

    void CompareSounds()
    {
        if (grabbedL == null || grabbedR == null) return;

        if(grabbedL == grabbedR)
        {
            grabbedSound = grabbedR;
        }
        else
        {
            grabbedSound = null;
        }
    }

    public void UnGrabbedLeft()
    {
        useingLeftHand = false;
        grabbedL = null;
        explosion.newSpawnedL = null;
        holdingTargetL = null;
        grabbedSound = null;
    }

    public void UnGrabbedRight()
    {
        useingRightHand = false;
        grabbedR = null;
        explosion.newSpawnedR = null;
        holdingTargetR = null;
        grabbedSound = null;
    }
}
