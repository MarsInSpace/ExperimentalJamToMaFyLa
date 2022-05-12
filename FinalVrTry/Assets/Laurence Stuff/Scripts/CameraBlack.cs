using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBlack : MonoBehaviour
{

    public Camera VRcamera;
    // Start is called before the first frame update
    void Start()
    {
        VRcamera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CameraCullingMenu()
    {
        VRcamera.cullingMask = LayerMask.GetMask("UI");
    }

    public void CameraCullingNothing()
    {
        VRcamera.cullingMask = LayerMask.GetMask("Everything");
    }
}
