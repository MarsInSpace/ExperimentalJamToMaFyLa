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

    public LayerMask insect;

    [SerializeField] public SteamVR_Behaviour_Pose leftContr;
    [SerializeField] public SteamVR_Behaviour_Pose rightContr;

    [HideInInspector]
    public GameObject grabbedSound;

    public GameObject grabbedL;
    public GameObject grabbedR;

    [SerializeField] public Rigidbody holdingTargetR;
    [SerializeField] public Rigidbody holdingTargetL;

    [SerializeField] string insectSoundName;

    public GameObject grabbedInsectL;
    public GameObject grabbedInsectR;

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
            Collider[] pickUpColliders = Physics.OverlapSphere(leftContr.transform.position, distToPickUp, pickUpLayer);
            if (pickUpColliders.Length > 0)
            {
                holdingTargetL = pickUpColliders[0].gameObject.GetComponent<Rigidbody>();
                grabbedL = pickUpColliders[0].gameObject;
                
            }
            else
            {
                Collider[] insectColliders = Physics.OverlapSphere(leftContr.transform.position, distToPickUp, insect);
                if(insectColliders.Length > 0)
                {
                    grabbedInsectL = insectColliders[0].gameObject;
                }
            }
        }
        else
        {
            holdingTargetL.velocity = (leftContr.transform.position - holdingTargetL.transform.position) / Time.fixedDeltaTime;
            holdingTargetL.maxAngularVelocity = 15;
            SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.LeftHand].Execute(0, 1, 10, 1);
        }
            useingLeftHand = true;

        
    }
    public void GrabbedRight()
    {
        if (holdingTargetR == null)
        {
            Collider[] pickUpColliders = Physics.OverlapSphere(rightContr.transform.position, distToPickUp, pickUpLayer);
            if (pickUpColliders.Length > 0)
            {
                holdingTargetR = pickUpColliders[0].gameObject.GetComponent<Rigidbody>();
                grabbedR = pickUpColliders[0].gameObject;
            }
            else
            {
                Collider[] insectColliders = Physics.OverlapSphere(rightContr.transform.position, distToPickUp, insect);
                if (insectColliders.Length > 0)
                {
                    grabbedInsectR = insectColliders[0].gameObject;
                }
            }
        }
        else
        {
            holdingTargetR.velocity = (rightContr.transform.position - holdingTargetR.transform.position) / Time.fixedDeltaTime;
            holdingTargetR.maxAngularVelocity = 15;
            SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.RightHand].Execute(0, 1, 10, 1);
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
