using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PickUpSound : MonoBehaviour
{
    public bool handClosed;


    //SteamVR attempt

    /*public float distToPickUp = 0.5f;
    public SteamVR_Input_Sources HandSource = SteamVR_Input_Sources.LeftHand;
    public bool handClosed;
    public LayerMask pickUpLayer;

    Rigidbody holdingTarget;
    Sound grabbedSound;

    private void FixedUpdate()
    {
        if (SteamVR_Actions.default_GrabGrip.GetState(HandSource))
            handClosed = true;
        else
            handClosed = false;

        if(!handClosed)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, distToPickUp, pickUpLayer);
            if (colliders.Length > 0)
            {
                holdingTarget = colliders[0].transform.root.GetComponent<Rigidbody>();
                grabbedSound = colliders[0].transform.root.GetComponent<Sound>();
            }
            else
            {
                holdingTarget = null;
                grabbedSound = null;
            }
        }
        else
        {
            if(holdingTarget)
            {
                holdingTarget.velocity = (transform.position - holdingTarget.transform.position) / Time.fixedDeltaTime;
                holdingTarget.maxAngularVelocity = 20;
            }
        }
    }*/

}
