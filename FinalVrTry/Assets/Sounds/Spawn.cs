using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] FieldSizeManager field;
    [SerializeField] List<GameObject> SoundSources = new List<GameObject>();
    public List<GameObject> currentSounds = new List<GameObject>();
    public GameObject currentSound;

    public List<Vector3> spawnpoints = new List<Vector3>();
    float soundDistance;
    Vector3 front;
    Vector3 back;
    Vector3 left;
    Vector3 right;

    Quaternion rot = new Quaternion(0, 0, 0, 0);

    private void Start()
    {
        soundDistance = field.radius / 2;
        front = field.middle + new Vector3(soundDistance, field.height, 0);
        back = field.middle - new Vector3(soundDistance, -field.height, 0);
        left = field.middle - new Vector3(0, -field.height, soundDistance);
        right = field.middle + new Vector3(0, field.height, soundDistance);
        spawnpoints.Add(front); spawnpoints.Add(back); spawnpoints.Add(left); spawnpoints.Add(right);

        SoundSources.Add(Instantiate(SoundSources[Random.Range(0, SoundSources.Count)], spawnpoints[Random.Range(0, spawnpoints.Count)], rot));

        
    }

    private void Update()
    {
        for (var i = currentSounds.Count - 1; i > -1; i--)
        {
            if (currentSounds[i] == null)
                currentSounds.RemoveAt(i);
        }

        if (currentSounds.Count == 0)
        {
            currentSound = Instantiate(SoundSources[Random.Range(0, SoundSources.Count)], spawnpoints[Random.Range(0, spawnpoints.Count)], rot);
            currentSounds.Add(currentSound); 
        }
    }
}
