using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selfdestroy : MonoBehaviour
{
    Spawn spawn;
    FieldSizeManager field;

    private void Start()
    {
        spawn = FindObjectOfType<Spawn>().gameObject.GetComponent<Spawn>();
        field = FindObjectOfType<FieldSizeManager>().gameObject.GetComponent<FieldSizeManager>();
    }

    private void Update()
    {
        if(transform.position.x > field.radius + 4 || transform.position.x < -field.radius - 4 
            || transform.position.z > field.radius + 4 || transform.position.z < -field.radius - 4 
                || transform.position.y >field.height + 4 || transform.position.y < 0 -4)
        {
            spawn.currentSounds.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
