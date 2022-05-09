using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YeetSound : MonoBehaviour
{
    AudioSource audiSource;
    [SerializeField] AudioClip klirr;
    private Spawn spawn;
    Rigidbody rb;
    public float velocity;
    float waitlengh;
    public float mindestVelocity = 15;

    bool doomed = false;

    private void Start()
    {
        audiSource = gameObject.GetComponent<AudioSource>();
        spawn = FindObjectOfType<Spawn>().gameObject.GetComponent<Spawn>();
        rb = gameObject.GetComponent<Rigidbody>();
        waitlengh = klirr.length;
    }
    private void Update()
    {
        velocity = rb.velocity.magnitude;
        if (doomed)
        {
            waitlengh -= Time.deltaTime;
            audiSource.clip = klirr;
            if (waitlengh <= 0)
            {
                spawn.currentSounds.Remove(this.gameObject);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (velocity >= mindestVelocity)
            {
                doomed = true;
            }
        }
    }
}
