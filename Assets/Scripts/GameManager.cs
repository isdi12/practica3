using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // el gamemanager controla las variables que no se relacionan con otros gameobjects del juego 

    private float time;
    private int points;
    private void Awake()
    {
        if(!instance) // si instance no tiene informacion 
        {
            instance = this; // instance se asigna a este objeto 
            DontDestroyOnLoad(gameObject); // se indica que este obj no se destruya con la carga de escenas 
        }
        else // si instance tiene info 
        {
            Destroy(gameObject); // se destruye el gameObject, para que no haya dos mas gamemanagers en el juego

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
    
    public float GetTime()
    {
        return time;
    }
    // Getter
    public int GetPoints()
    {
        return points ; 
    }
    // setter
    public void SetPoints(int value)
    {
        points = value; 
    }
}
