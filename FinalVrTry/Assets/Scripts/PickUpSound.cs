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


    Rigidbody holdingTarget;
    public void GrabbedLeft()
    {
        if (useingRightHand == false)
        {
            Collider[] colliders = Physics.OverlapSphere(leftContr.transform.position, distToPickUp, pickUpLayer);
            if (colliders.Length > 0)
            {
                holdingTarget = colliders[0].transform.root.GetComponent<Rigidbody>();
                grabbedSound = colliders[0].gameObject;
            }
            holdingTarget.velocity = (leftContr.transform.position - holdingTarget.transform.position) / Time.fixedDeltaTime;
            holdingTarget.maxAngularVelocity = 15;
            useingLeftHand = true;
        }
    }
    public void GrabbedRight()
    {
        if (useingLeftHand == false)
        {
            Collider[] colliders = Physics.OverlapSphere(rightContr.transform.position, distToPickUp, pickUpLayer);
            if (colliders.Length > 0)
            {
                holdingTarget = colliders[0].transform.root.GetComponent<Rigidbody>();
                grabbedSound = colliders[0].gameObject;
            }
            holdingTarget.velocity = (rightContr.transform.position - holdingTarget.transform.position) / Time.fixedDeltaTime;
            holdingTarget.maxAngularVelocity = 15;
            useingRightHand = true;
        }
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
