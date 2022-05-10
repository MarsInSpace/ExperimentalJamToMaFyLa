using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YeetSound : MonoBehaviour
{
    AudioSource audiSource;
    [SerializeField] AudioClip klirr;
    private Spawn spawn;
    PickUpSound pickUpSound;
    Rigidbody rb;
    public float velocity;
    public float waitlengh;
    public float mindestVelocity = 15;

    bool doomed = false;

    private void Start()
    {
        audiSource = gameObject.GetComponent<AudioSource>();
        pickUpSound = FindObjectOfType<PickUpSound>().gameObject.GetComponent<PickUpSound>();
        spawn = FindObjectOfType<Spawn>().gameObject.GetComponent<Spawn>();
        rb = gameObject.GetComponent<Rigidbody>();
        waitlengh = klirr.length;
    }
    private void Update()
    {
        velocity = rb.velocity.magnitude;
        if (doomed)
        {
            rb.velocity = Vector3.zero;
            waitlengh -= Time.deltaTime;
            
            if (waitlengh <= 0)
            {
                spawn.currentSounds.Remove(this.gameObject);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (pickUpSound.grabbedL == this.gameObject || pickUpSound.grabbedR == this.gameObject) return;
        
        if (collision.gameObject.layer == 6)
        {
            if (velocity >= mindestVelocity)
            {
                audiSource.clip = klirr;
                audiSource.Play();
                doomed = true;
            }
         }
        
    }
}
