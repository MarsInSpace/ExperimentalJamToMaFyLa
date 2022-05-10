using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] FieldSizeManager field;
    [SerializeField] public List<GameObject> SoundSources = new List<GameObject>();
    public List<GameObject> currentSounds = new List<GameObject>();
    public GameObject currentSound;

    public List<GameObject> spawnpoints = new List<GameObject>();
    float soundDistance;
    public GameObject front;
    public GameObject back;
    public GameObject left;
    public GameObject right;

    Quaternion rot = new Quaternion(0, 0, 0, 0);

    private void Start()
    {
        soundDistance = field.radius / 2;
        front.transform.position = field.middle + new Vector3(soundDistance, field.height, 0);
        back.transform.position = field.middle - new Vector3(soundDistance, -field.height, 0);
        left.transform.position = field.middle - new Vector3(0, -field.height, soundDistance);
        right.transform.position = field.middle + new Vector3(0, field.height, soundDistance);
        spawnpoints.Add(front); spawnpoints.Add(back); spawnpoints.Add(left); spawnpoints.Add(right);
    }

    private void Awake()
    {
        front = GameObject.Find("SpawnColliderFront");
        back = GameObject.Find("SpawnColliderBack");
        left = GameObject.Find("SpawnColliderLeft");
        right = GameObject.Find("SpawnColliderRight");
        
    }

    private void Update()
    {
        for (var i = currentSounds.Count - 1; i > -1; i--)
        {
            if (currentSounds[i] == null)
                currentSounds.RemoveAt(i);
        }

        if (currentSounds.Count == 0 && spawnpoints.Count != 0)
        {
            currentSound = Instantiate(SoundSources[Random.Range(0, SoundSources.Count)], spawnpoints[Random.Range(0, spawnpoints.Count)].transform.position, rot, field.gameObject.transform.parent);
            currentSounds.Add(currentSound); 
        }
    }
}
