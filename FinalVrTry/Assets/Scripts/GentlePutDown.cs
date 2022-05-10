using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GentlePutDown : MonoBehaviour
{
    YeetSound yeet;
    public float maxVelocity;
    Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        yeet = gameObject.GetComponent<YeetSound>();
    }

    private void Update()
    {
        if(yeet.velocity < maxVelocity)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
