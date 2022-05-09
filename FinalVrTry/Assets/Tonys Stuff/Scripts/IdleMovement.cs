using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMovement : MonoBehaviour
{
    public FieldSizeManager fieldSizeManagerScr;

    public Vector3 idleMovementPoint;


    float maxHeight;
    float maxWidth;

    float soundObjRadius = 0.25f;

    public bool determineVariablesNew = false;
    public bool generateNewDestination = false;

    public GameObject testCube;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(determineVariablesNew)
        {
            DetermineVariables();
            determineVariablesNew = false;
        }
        if(generateNewDestination)
        {
            GenerateNewIdleMovementDestination();
            generateNewDestination = false;
        }
    }

    void DetermineVariables()
    {
        maxHeight = fieldSizeManagerScr.height + fieldSizeManagerScr.armLength - soundObjRadius; // der float am ende, weil die Soundkugeln die sich dann bewegen ja auch einen Radius haben und an der Barriere abprallen
        maxWidth = fieldSizeManagerScr.radius - soundObjRadius - (fieldSizeManagerScr.radius / 4.8f); // hier steht die zwanzigstel für den teil, der vom achteck abgeschnitten wird an den langen kanten
    }

    void GenerateNewIdleMovementDestination()
    {
        idleMovementPoint = new Vector3(Random.Range(-maxWidth, maxWidth), Random.Range(0 + soundObjRadius, maxHeight), Random.Range(-maxWidth, maxWidth));
        SetCubeToSpot();
    }

    void SetCubeToSpot()
    {
        testCube.transform.position = idleMovementPoint;
    }
}
