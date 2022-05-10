using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillInsect : MonoBehaviour
{
    public PickUpSound pickUpScr;

    public Spawn spawnScr;

    public GameObject insectDeathSoundPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfInsectDead();
    }

    void CheckIfInsectDead()
    {
        if(pickUpScr.grabbedInsectL)
        {
            KillThatInsect(pickUpScr.grabbedInsectL);
        }
        if(pickUpScr.grabbedInsectR)
        {
            KillThatInsect(pickUpScr.grabbedInsectR);
        }
    }

    // plan : spawntan der Stelle der toten Mücke dann einen deathsound. dieser deathsound löscht sich dnn nach einer gewissen Zeit selbst wieder
    void KillThatInsect(GameObject insect)
    {
        spawnScr.currentSounds.Remove(insect);

        Instantiate(insectDeathSoundPrefab, insect.transform.position, insect.transform.rotation);

        Destroy(insect);
    }
}
