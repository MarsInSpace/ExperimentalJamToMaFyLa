using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] FieldSizeManager field;
    [SerializeField] public List<GameObject> SoundSources = new List<GameObject>();
    public List<GameObject> currentSounds = new List<GameObject>();
    public GameObject currentSound;

    public bool mayhem = false;

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
            float MinY = 1f;
            float MaxY = field.height;
            float MinZ = -field.radius / 2;
            float MaxZ = field.radius/2;

            float x = Random.Range(MinX, MaxX);
            float y = Random.Range(MinY, MaxY);
            float z = Random.Range(MinZ, MaxZ);

            if (!mayhem)
            {
                currentSound = Instantiate(SoundSources[Random.Range(0, SoundSources.Count)], new Vector3(x, y, z), Quaternion.identity, field.gameObject.transform.parent);
                currentSounds.Add(currentSound);
            }

            if(mayhem)
            {
                Debug.Log("instantiate " + SoundSources[2]);
                currentSound = Instantiate(SoundSources[2], new Vector3(x, y, z), Quaternion.identity, field.gameObject.transform.parent);
                currentSounds.Add(currentSound);
                currentSound = Instantiate(SoundSources[2], new Vector3(x, y, z), Quaternion.identity, field.gameObject.transform.parent);
                currentSounds.Add(currentSound);
            }
        }
    }

    public void ToggleMayhem()
    {
        mayhem = true;
    }

}
