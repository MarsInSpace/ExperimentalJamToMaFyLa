using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PickUpSound : MonoBehaviour
{
    public bool useingLeftHand =false;
    public bool useingRightHand = false;
    public bool handClosed;

    public float distToPickUp = 0.5f;
   
    public LayerMask pickUpLayer;

    [SerializeField] public SteamVR_Behaviour_Pose leftContr;
    [SerializeField] public SteamVR_Behaviour_Pose rightContr;

    public GameObject grabbedSound;


    Rigidbody holdingTargetR;

    Rigidbody holdingTargetL;


    public void GrabbedLeft()
    {
        Collider[] colliders = Physics.OverlapSphere(leftContr.transform.position, distToPickUp, pickUpLayer);
        if (colliders.Length > 0)
        {
            holdingTargetL = colliders[0].gameObject.GetComponent<Rigidbody>();
            grabbedSound = colliders[0].gameObject;
        }
        holdingTargetL.velocity = (leftContr.transform.position - holdingTargetL.transform.position) / Time.fixedDeltaTime;
        holdingTargetL.maxAngularVelocity = 15;
        useingLeftHand = true;
    }
    public void GrabbedRight()
    {
        Collider[] colliders = Physics.OverlapSphere(rightContr.transform.position, distToPickUp, pickUpLayer);
        if (colliders.Length > 0)
        {
            holdingTargetR = colliders[0].gameObject.GetComponent<Rigidbody>();
            grabbedSound = colliders[0].gameObject;
        }
        holdingTargetR.velocity = (rightContr.transform.position - holdingTargetR.transform.position) / Time.fixedDeltaTime;
        holdingTargetR.maxAngularVelocity = 15;
        useingRightHand = true;
    }

    public void UnGrabbedLeft()
    {
        useingLeftHand = false;
    }

    public void UnGrabbedRight()
    {
        useingRightHand = false;
    }



}
