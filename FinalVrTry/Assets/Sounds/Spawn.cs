using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] List<GameObject> SoundSources = new List<GameObject>();
    public List<GameObject> currentSounds = new List<GameObject>();
    public GameObject currentSound;

    Vector3 pos = new Vector3(0, 0, 0);
    Quaternion rot = new Quaternion(0, 0, 0, 0);

    private void Start()
    {
        if (currentSounds.Count == 0)
        {
            currentSound = Instantiate(SoundSources[Random.Range(0, SoundSources.Count)], pos, rot);
            currentSounds.Add(currentSound);
        }
    }
}
