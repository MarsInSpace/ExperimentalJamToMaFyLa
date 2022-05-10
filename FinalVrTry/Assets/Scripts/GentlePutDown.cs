using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GentlePutDown : MonoBehaviour
{
    PickUpSound pickUp;
    Explosion explosion;
    public float maxVelocity;
    float cursedTimerL = 0.1f;
    float cursedTimerR = 0.1f;

    GameObject justGrabbedL;
    GameObject justGrabbedR;

    private void Start()
    {
        pickUp = FindObjectOfType<PickUpSound>().gameObject.GetComponent<PickUpSound>();
        explosion = FindObjectOfType<Explosion>().gameObject.GetComponent<Explosion>();

    }

    private void Update()
    {
        CheckVelLeft();
        CheckVelRight();

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
        else if (justGrabbedL != null)
        {
            if (explosion.contrVelLeft <= maxVelocity)
            {
               if (pickUp.useingLeftHand == false && cursedTimerL > 0)
                {
                    cursedTimerL -= Time.deltaTime;
                    justGrabbedL.GetComponent<Rigidbody>().velocity = Vector3.zero;                    
                }
            }
        }
        if(pickUp.useingLeftHand == true)
        {
            cursedTimerL = 0.01f;
        }

        if(cursedTimerL <= 0)
        {
            justGrabbedL = null;
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
        else if (justGrabbedR != null)
        {
            if (explosion.contrVelRight <= maxVelocity)
            {
                if (pickUp.useingRightHand == false)
                {
                    justGrabbedR.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    justGrabbedR = null;
                }
            }
            
        }
    }

}
