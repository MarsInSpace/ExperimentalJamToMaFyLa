using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHeadMovement : MonoBehaviour
{
    [SerializeField] float speed;

    private Rigidbody rb;
    public float rotationSpeed;
    Vector3 movement;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 forwardMovement;

        if (Input.GetKey(KeyCode.W))
            forwardMovement = transform.forward * 1;
        else if (Input.GetKey(KeyCode.S))
            forwardMovement = transform.forward * -1;
        else 
            forwardMovement = transform.forward * 0;

        movement = forwardMovement;
        movement = movement.normalized * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -1 * Time.deltaTime * rotationSpeed, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 1 * Time.deltaTime * rotationSpeed, 0));
        }

        if (movement == Vector3.zero)
        {
            rb.velocity = Vector3.zero; // muss ich machen, weil der rigidbody von den bullets getroffen wird und dann trotz keiner grdrückter tasten rumfloated
            //Debug.Log("movement zero");
        }

        transform.position += movement;
    }
}