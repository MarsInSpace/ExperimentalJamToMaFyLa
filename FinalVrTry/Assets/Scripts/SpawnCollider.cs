using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSpawnpoint : MonoBehaviour
{
    [SerializeField] Spawn spawn;
    public bool inUse = false;
    
    private void OnTriggerEnter(Collider other)
    {
        inUse = true;
        spawn.spawnpoints.Remove(gameObject);
       // Debug.Log("trigger entered");
    }

    private void OnTriggerExit(Collider other)
    {
        inUse = false;
        spawn.spawnpoints.Add(gameObject);
       // Debug.Log("trigger exit");
    }
}
