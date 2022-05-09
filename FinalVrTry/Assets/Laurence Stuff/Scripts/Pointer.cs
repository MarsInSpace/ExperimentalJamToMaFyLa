using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour
{
    public float m_Defaultlength = 5.0f;

    public GameObject m_Dot;

    public InputModule m_InputModule;


    
    private void Awake()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {

        PointerEventData data = m_InputModule.GetData();

        float targetLength = data.pointerCurrentRaycast.distance == 0 ? m_Defaultlength : data.pointerCurrentRaycast.distance;

        RaycastHit hit = CreateRaycast(targetLength);

        Vector3 endPosition = transform.position + (transform.forward * targetLength);

        if(hit.collider != null)
        {
            endPosition = hit.point;
        }

        m_Dot.transform.position = endPosition;


    }


    private RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, m_Defaultlength);

        return hit;
    }
}
