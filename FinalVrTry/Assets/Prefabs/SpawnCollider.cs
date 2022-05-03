using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSpawnpoint : MonoBehaviour
{
    [SerializeField] Spawn spawn;
    public bool inUse = false;
    
    private void OnCollisionStay(Collision collision)
    {
            inUse = true;
            spawn.spawnpoints.Remove(gameObject);
        
    }

    private void OnCollisionExit(Collision collision)
    {
        inUse = false;
        spawn.spawnpoints.Add(gameObject);
    }



}
