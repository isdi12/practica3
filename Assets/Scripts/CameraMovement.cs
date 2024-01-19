using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject rana;
    

    private void Update()
    {
      transform.position = new Vector3(rana.transform.position.x,transform.position.y,transform.position.z);
    
    }
}
