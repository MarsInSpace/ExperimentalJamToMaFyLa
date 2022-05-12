using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] FieldSizeManager field;
    [SerializeField] public List<GameObject> SoundSources = new List<GameObject>();
    public List<GameObject> currentSounds = new List<GameObject>();
    public GameObject currentSound;

    private void Update()
    {
        for (var i = currentSounds.Count - 1; i > -1; i--)
        {
            if (currentSounds[i] == null)
                currentSounds.RemoveAt(i);
        }


        if (currentSounds.Count == 0)
        {
            float MinX = -field.radius / 2;
            float MaxX = field.radius/2;
            float MinY = 0.25f;
            float MaxY = field.height;
            float MinZ = -field.radius / 2;
            float MaxZ = field.radius/2;

            float x = Random.Range(MinX, MaxX);
            float y = Random.Range(MinY, MaxY);
            float z = Random.Range(MinZ, MaxZ);
            currentSound = Instantiate(SoundSources[Random.Range(0, SoundSources.Count)], new Vector3(x,y,z), Quaternion.identity, field.gameObject.transform.parent);
            currentSounds.Add(currentSound); 
        }
    }

}
