using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectBehaviour : MonoBehaviour
{
    public FieldSizeManager fieldSizeManagerScr;

    public Vector3 idleMovementPoint;

    float speed = .5f;

    float minDistanceToDestination = .01f;


    float maxHeight;
    float maxWidth;

    float soundObjRadius = 0.25f;

    public bool determineVariablesNew = false;
    public bool generateNewDestination = false;

    GameObject testCube;

    Rigidbody rb;

    bool nextDirectionSet = false;
    Vector3 movementDirection;

    float distanceToNextPoint;

    [SerializeField] bool reachedDestination = true;

    bool wasInSetup = false;

    bool InPlayField = false;

    // Start is called before the first frame update
    void Start()
    {
        fieldSizeManagerScr = GameObject.FindGameObjectWithTag("FieldSizeManager").GetComponent<FieldSizeManager>();

        testCube = this.gameObject;
        rb = testCube.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        DetermineVariables();
    }

    // Update is called once per frame
    void Update()
    {
        if(wasInSetup && !fieldSizeManagerScr.inSetup) // das funktioniert so nur, wenn der Sou nd auch vor dem beenden des Setups gespawned wird
        {
            DetermineVariables();
        }


        if (!fieldSizeManagerScr.inSetup)
        {
            if (reachedDestination) generateNewDestination = true;


            if (determineVariablesNew)
            {
                DetermineVariables();
                determineVariablesNew = false;
            }
            if (generateNewDestination)
            {
                GenerateNewIdleMovementDestination();
                generateNewDestination = false;
            }

            CalculateDistance();
            RegulateStopMovement();
        }

        if (fieldSizeManagerScr.inSetup)
        {
            wasInSetup = true;
        }
        else
        {
            wasInSetup = false;
        }
    }

    private void FixedUpdate()
    {
        if(!reachedDestination)
            FlyToNextPoint();
    }

    void DetermineVariables()
    {
        maxHeight = fieldSizeManagerScr.height + fieldSizeManagerScr.armLength - soundObjRadius; // der float am ende, weil die Soundkugeln die sich dann bewegen ja auch einen Radius haben und an der Barriere abprallen
        maxWidth = fieldSizeManagerScr.radius - soundObjRadius - (fieldSizeManagerScr.radius / 4.8f); // hier steht die zwanzigstel für den teil, der vom achteck abgeschnitten wird an den langen kanten
    }

    void GenerateNewIdleMovementDestination()
    {
        idleMovementPoint = new Vector3(Random.Range(-maxWidth, maxWidth), Random.Range(0 + soundObjRadius, maxHeight), Random.Range(-maxWidth, maxWidth));
        reachedDestination = false;
        nextDirectionSet = false;
        //SetCubeToSpot();
    }

    void SetCubeToSpot()
    {
        testCube.transform.position = idleMovementPoint;
    }

    void FlyToNextPoint()
    {
        if (nextDirectionSet == false)
        {
            movementDirection = idleMovementPoint - testCube.transform.position;
            movementDirection = movementDirection.normalized;
            nextDirectionSet = true;
        }

        Debug.DrawRay(testCube.transform.position,movementDirection);
        rb.MovePosition(testCube.transform.position + movementDirection * Time.deltaTime * speed);

        /*Quaternion rotation = Quaternion.LookRotation(movementDirection, testCube.transform.up);
        rb.MoveRotation(rotation);*/
    }

    void CalculateDistance()
    {
        distanceToNextPoint = Vector3.Distance(idleMovementPoint, testCube.transform.position);
    }

    void RegulateStopMovement()
    {
        if((testCube.transform.position.x < maxWidth && testCube.transform.position.z < maxWidth && testCube.transform.position.y < maxHeight))
        {
            InPlayField = true;
        }

        if(InPlayField && (testCube.transform.position.x > maxWidth || testCube.transform.position.z > maxWidth || testCube.transform.position.y > maxHeight))
        {
            reachedDestination = true;
            InPlayField = false;
        }

        if(distanceToNextPoint <= minDistanceToDestination)
        {
            reachedDestination = true;
        }
    }
}
