using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSpawnpoint : MonoBehaviour
{
    Spawn spawn;
    public bool inUse = false;

    private void Start()
    {
        spawn = FindObjectOfType<Spawn>().gameObject.GetComponent<Spawn>();
    }

    private void OnTriggerEnter(Collider other)
    {
        inUse = true;
       // spawn.spawnpoints.Remove(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        inUse = false;
        //spawn.spawnpoints.Add(gameObject);
    }
}
