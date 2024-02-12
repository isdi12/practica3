using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject rana;
    

    private void Update()
    {
        if (rana != null)
            transform.position = new Vector3(rana.transform.position.x,rana.transform.position.y,transform.position.z);  
    }
}
