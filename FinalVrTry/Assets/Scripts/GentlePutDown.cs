using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GentlePutDown : MonoBehaviour
{
    PickUpSound pickUp;
    public Rigidbody holdedTargetL;
    Rigidbody holdedTargetR;

    public float cursedTimer = 0.01f;
    public float cursedTimerL;
    float cursedTimerR;
    public float maxVelocity;

    private void Start()
    {
        pickUp = FindObjectOfType<PickUpSound>().gameObject.GetComponent<PickUpSound>();
        //explosion = FindObjectOfType<Explosion>().gameObject.GetComponent<Explosion>();
    }

    private void Update()
    {
        if(pickUp.useingLeftHand == true)
        {
            holdedTargetL = pickUp.holdingTargetL;
            cursedTimerL = cursedTimer;
            Debug.Log("holding target");
        }
        else
        {
            cursedTimerL -= Time.deltaTime;
        }

        if (pickUp.useingLeftHand == false)
        {
            if (holdedTargetL == null) return;

            if (holdedTargetL.velocity.magnitude <= maxVelocity && cursedTimerL >= 0)
            {
                Debug.Log("velocity nulled");
                holdedTargetL.velocity = Vector3.zero;
                holdedTargetL = null;
            }
        }



        if (pickUp.useingRightHand == true)
        {
            holdedTargetR = pickUp.holdingTargetR;
            cursedTimerR = cursedTimer;
        }
        else
        {
            cursedTimerR -= Time.deltaTime;
        }

        if (pickUp.useingRightHand == false)
        {
            if (holdedTargetR == null) return;

            if (holdedTargetR.velocity.magnitude <= maxVelocity && cursedTimerR >= 0)
            {
                holdedTargetR.velocity = Vector3.zero;
                holdedTargetR = null;
            }
        }
    }

    //PickUpSound pickUp;
    //Explosion explosion;
    //public float maxVelocity;
    //float cursedTimerL = 0.1f;
    //float cursedTimerR = 0.1f;

    //public GameObject justGrabbedL;
    //public GameObject justGrabbedR;

    //private void Start()
    //{
    //    pickUp = FindObjectOfType<PickUpSound>().gameObject.GetComponent<PickUpSound>();
    //    explosion = FindObjectOfType<Explosion>().gameObject.GetComponent<Explosion>();

    //}

    //private void Update()
    //{
    //    CheckVelLeft();
    //    CheckVelRight();

    //}

    //void CheckVelLeft()
    //{
    //    if (justGrabbedL == null)
    //    {
    //        if (pickUp.useingLeftHand)
    //        {
    //            justGrabbedL = pickUp.grabbedL;
    //        }
    //    }
    //    else if (justGrabbedL != null)
    //    {
    //        if (explosion.contrVelLeft <= maxVelocity)
    //        {
    //           if (pickUp.useingLeftHand == false && cursedTimerL > 0)
    //            {
    //                cursedTimerL -= Time.deltaTime;
    //                justGrabbedL.GetComponent<Rigidbody>().velocity = Vector3.zero;                    
    //            }
    //        }
    //    }
    //    if(pickUp.useingLeftHand == true)
    //    {
    //        cursedTimerL = 0.01f;
    //    }

    //    if(cursedTimerL <= 0)
    //    {
    //        justGrabbedL = null;
    //    }
    //}

    //void CheckVelRight()
    //{
    //    if (justGrabbedR == null)
    //    {
    //        if (pickUp.useingRightHand)
    //        {
    //            justGrabbedR = pickUp.grabbedR;
    //        }
    //    }
    //    else if (justGrabbedR != null)
    //    {
    //        if (explosion.contrVelRight <= maxVelocity)
    //        {
    //            if (pickUp.useingRightHand == false)
    //            {
    //                justGrabbedR.GetComponent<Rigidbody>().velocity = Vector3.zero;
    //                justGrabbedR = null;
    //            }
    //        }

    //    }
    //}

}
