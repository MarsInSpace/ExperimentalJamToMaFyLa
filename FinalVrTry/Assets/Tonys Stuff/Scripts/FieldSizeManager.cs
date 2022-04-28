using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSizeManager : MonoBehaviour
{
    public float radius;
    public GameObject playerHead;

    float height;
    Vector3 middle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetMiddle()
    {
        middle = new Vector3(playerHead.transform.position.x ,0, playerHead.transform.position.z);
    }

    void SetSize()
    {

    }


}
