using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GentlePutDown : MonoBehaviour
{
    PickUpSound pickUp;
    Explosion explosion;
    YeetSound yeet;
    public float maxVelocity;
    Rigidbody rb;

    GameObject justGrabbedL;
    GameObject justGrabbedR;

    private void Start()
    {
        pickUp = FindObjectOfType<PickUpSound>().gameObject.GetComponent<PickUpSound>();
        explosion = FindObjectOfType<Explosion>().gameObject.GetComponent<Explosion>();
        rb = gameObject.GetComponent<Rigidbody>();
        yeet = gameObject.GetComponent<YeetSound>();
    }

    private void Update()
    {
        CheckVelLeft();
        CheckVelRight();

        //if(yeet.velocity < maxVelocity)
        //{
        //    rb.velocity = Vector3.zero;
        //}
    }

    void CheckVelLeft()
    {
        if (justGrabbedL == null)
        {
            if (pickUp.useingLeftHand)
            {
                justGrabbedL = pickUp.grabbedL;
            }
        }
        else
        {
            if (explosion.contrVelLeft <= maxVelocity)
            {
                if (pickUp.useingLeftHand == false)
                {
                    if (justGrabbedL != null)
                    {
                        justGrabbedL.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        justGrabbedL = null;
                    }
                }
            }
        }
    }

    void CheckVelRight()
    {
        if (justGrabbedR == null)
        {
            if (pickUp.useingRightHand)
            {
                justGrabbedR = pickUp.grabbedR;
            }
        }
        else
        {
            if (explosion.contrVelRight <= maxVelocity)
            {
                if (pickUp.useingRightHand == false)
                {
                    if (justGrabbedR != null)
                    {
                        justGrabbedR.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        justGrabbedR = null;
                    }
                }
            }
        }
    }

}
