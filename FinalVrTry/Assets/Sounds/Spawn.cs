using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] List<GameObject> SoundSources = new List<GameObject>();

    Vector3 pos = new Vector3(0, 0, 0);
    Quaternion rot = new Quaternion(0, 0, 0, 0);

    private void Start()
    {
        Instantiate(SoundSources[Random.Range(0, SoundSources.Count)], pos, rot);
    }
}
