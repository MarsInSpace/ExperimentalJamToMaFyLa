using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSizeManager : MonoBehaviour // wir müssen einbauen, dass bei jedem Spielneustart einmal die Höhe eingestellt wird
{
    public float radius;
    public GameObject playerHead;

    public GameObject gameFieldPrefab;

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
        if(setNewMiddle)
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
}
