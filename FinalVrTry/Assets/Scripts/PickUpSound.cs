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

    [SerializeField] SteamVR_Behaviour_Pose leftContr;
    [SerializeField] SteamVR_Behaviour_Pose rightContr;

    public GameObject grabbedSound;


    Rigidbody holdingTarget;
    public void GrabbedLeft()
    {
        

        Collider[] colliders = Physics.OverlapSphere(leftContr.transform.position, distToPickUp, pickUpLayer);
        if (colliders.Length > 0)
        {
            holdingTarget = colliders[0].transform.root.GetComponent<Rigidbody>();
            grabbedSound = colliders[0].transform.root.GetComponent<GameObject>();
        }
        holdingTarget.velocity = (leftContr.transform.position - holdingTarget.transform.position) / Time.fixedDeltaTime;
        holdingTarget.maxAngularVelocity = 15;
        useingLeftHand = true;
    }
    public void GrabbedRight()
    {
        

        Collider[] colliders = Physics.OverlapSphere(rightContr.transform.position, distToPickUp, pickUpLayer);
        if (colliders.Length > 0)
        {
            holdingTarget = colliders[0].transform.root.GetComponent<Rigidbody>();
            grabbedSound = colliders[0].transform.root.GetComponent<GameObject>();
        }
        holdingTarget.velocity = (rightContr.transform.position - holdingTarget.transform.position) / Time.fixedDeltaTime;
        holdingTarget.maxAngularVelocity = 15;
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


    //-------failed Attempto--------


    /*public bool handClosed;
     public SteamVR_Input_Sources HandSource = SteamVR_Input_Sources.LeftHand;
    public int handCounter;
    

    private void //FixedUpdate()
    {
        if (SteamVR_Actions.default_GrabGrip.GetState(HandSource))
            handClosed = true;
        else
            handClosed = false;

        if(!handClosed)
        {
            useingRightHand = false;
            useingLeftHand = false;

            Collider[] colliders = Physics.OverlapSphere(transform.position, distToPickUp, pickUpLayer);
            if (colliders.Length > 0)
            {
                holdingTarget = colliders[0].transform.root.GetComponent<Rigidbody>();
                grabbedSound = colliders[0].transform.root.GetComponent<GameObject>();          
            }
            else
            {
                holdingTarget = null;
                grabbedSound = null;
            }
            //handCounter = 0;
            
        }
        else
        {
            handCounter++;
            if (HandSource == SteamVR_Input_Sources.LeftHand)
            {
                useingLeftHand = true;
            }
            else
            {
                useingRightHand = true;
            }

            if (holdingTarget)
            {
                holdingTarget.velocity = (transform.position - holdingTarget.transform.position) / Time.fixedDeltaTime;
                holdingTarget.maxAngularVelocity = 20;
            }
        }
    }*/

}
