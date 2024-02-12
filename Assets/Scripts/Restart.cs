using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    public void RestartScene()
    {
        GameManager.instance.LoadScene("SampleScene"); //con esto llevamos el reinicio del juego al loadscene del game manager y ejecutara su metodo 
        GameManager.instance.SetIsDead(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
