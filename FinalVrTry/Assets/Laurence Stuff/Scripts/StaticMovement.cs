using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMovement : MonoBehaviour

{
    public Rigidbody rb;

    public float x = 10;
    public float y = 10;
    public float z = 0;

    public FieldSizeManager fieldsizemanager;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (fieldsizemanager.inSetup == false)
            rb.velocity = new Vector3(x, y, z);

    }
}
