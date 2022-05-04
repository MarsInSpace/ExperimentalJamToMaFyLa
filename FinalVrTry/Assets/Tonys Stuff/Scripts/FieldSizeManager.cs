using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSizeManager : MonoBehaviour // wir müssen einbauen, dass bei jedem Spielneustart einmal die Höhe eingestellt wird
{
    public float radius;
    public GameObject playerHead;

    public GameObject gameFieldPrefab;

    public AudioSource middleAudio;
    public AudioSource heightAudio;
    

    public float childArmLength;
    public float adultArmLength;

    public float height = 1.75f;
    public Vector3 middle;

    float lastRadius;
    public bool setNewMiddle = false;

    public bool setNewHeight;

    GameObject[] walls;
    GameObject ceiling;

    float armLength; // damit kinder auch das spiel spielen können

    public bool startSetup = true;
    public bool inSetup = false;

    public bool middleCalibrated = false;
    public bool heightCalibrated = false;

    bool triggerPressed = false;

    bool heightAudioPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        walls = GameObject.FindGameObjectsWithTag("Wall");
        ceiling = GameObject.FindGameObjectWithTag("Ceiling");

        DetermieHeight();
        SetHeigth();
    }

    // Update is called once per frame
    void Update()
    {
        if (startSetup || inSetup)
        {
            Setup();
        }

        if (setNewMiddle)
        {
            setNewHeight = true;
        }

        ManageHeight();

        if (radius != lastRadius)
        {
            RadiusChanged();
        }

        if(setNewMiddle)
        {
            SetMiddle();
        }

        lastRadius = radius;
    }

    void SetMiddle()
    {
        middle = new Vector3(playerHead.transform.position.x ,0, playerHead.transform.position.z);
        gameFieldPrefab.transform.position = middle;
        setNewMiddle = false;
    }

    void SetWidth()
    {
        gameFieldPrefab.transform.localScale = new Vector3(radius*2, gameFieldPrefab.transform.localScale.y, radius*2);
    }

    void SetHeigth() // die wände werden entsprechend hoch gescaled und die Mitte der Wände wird auf die hälfte gesetzt. die Decke wird weiter oben positioniert
    {
        foreach(GameObject wall in walls)
        {
            wall.transform.localScale = new Vector3(wall.transform.localScale.x, height + armLength, wall.transform.localScale.x);
        }

        ceiling.transform.position = new Vector3(ceiling.transform.position.x, height + armLength - 0.1f, ceiling.transform.position.z);

        setNewHeight = false;
    }

    void RadiusChanged()
    {
        SetWidth();
    }

    void DetermieHeight()
    {
        height = playerHead.transform.position.y;

        if(height <= 1.2f)
        {
            armLength = childArmLength;
        }
        else
        {
            armLength = adultArmLength;
        }    
    }

    void ManageHeight()
    {
        if (!setNewHeight) return;

        DetermieHeight();

        SetHeigth();
    }


    void Setup()
    {
        ButtonsPressedInSetup();

        if (startSetup)
        {
            inSetup = true;
            middleCalibrated = false;
            heightCalibrated = false;
            startSetup = false;

            StartCoroutine(PlayMiddleAudio());
        }

        if (!middleCalibrated) return;

        middleAudio.Stop(); // hier ist die Mitte kaalibriert worden, audio geht wieder aus

        if(!heightAudioPlaying)
        {
            StartCoroutine(PlayHeightAudio());
            heightAudioPlaying = true;
        }

        if (!heightCalibrated) return;
        else heightAudioPlaying = false;

        heightAudio.Stop();
        inSetup = false;
    }

    IEnumerator PlayMiddleAudio()
    {
        yield return new WaitForSeconds(1);

        middleAudio.Play();
        Debug.Log("started middle Audio");
    }

    IEnumerator PlayHeightAudio()
    {
        yield return new WaitForSeconds(1);

        heightAudio.Play();
        Debug.Log("started height Audio");
    }

    void ButtonsPressedInSetup()
    {
        if(triggerPressed && !middleCalibrated)
        {
            setNewMiddle = true;
            middleCalibrated = true;
            triggerPressed = false;
        }
        else if(triggerPressed && middleCalibrated && !heightCalibrated)
        {
            setNewHeight = true;
            heightCalibrated = true;
            triggerPressed = false;
        }
    }

    public void TriggerPressed()
    {
        if (!inSetup) return;
        else
        {
            triggerPressed = true;
            Debug.Log("pressed Trigger");
        }
    }
}
