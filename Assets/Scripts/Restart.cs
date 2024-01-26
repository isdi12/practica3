using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    public void RestartScene()
    {
        SceneManager.LoadScene("SampleScene"); // con esto al apretar el boton reiniciara el juego 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
