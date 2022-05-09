using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectedListening : MonoBehaviour
{
    public float rightDistance;
    public float leftDistance;

    GameObject playerHead;

    public GameObject rightContrl;
    public GameObject leftContrl;

    public bool rightEarListening = false;
    public bool leftEarListening = false;

    public float minDistanceToEar;


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
    }

    public void CalculateDistanceToRightContrl()
    {
        rightDistance = Vector3.Distance(playerHead.transform.position, rightContrl.transform.position);
        if (rightDistance <= minDistanceToEar)
        {
            rightEarListening = true;
        }
        else
            rightEarListening = false;
    }


    public void CalculateDistanceToLeftContrl()
    {
        leftDistance = Vector3.Distance(playerHead.transform.position, leftContrl.transform.position);
        if (leftDistance <= minDistanceToEar)
        {
            leftEarListening = true;
        }
        else
            leftEarListening = false;
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

        if (Physics.SphereCast(playerHead.transform.position, .2f, directionDetermination * transform.right, out hit, Mathf.Infinity, ~LayerMask.GetMask("Default")) && hit.collider.gameObject.layer == 3)
        {
            Debug.Log("spherecast to listen hit something" + hit.collider.gameObject.layer);
            hit.collider.gameObject.GetComponent<ManageSoundVolume>().inFocus = true;
        }

    }
}
