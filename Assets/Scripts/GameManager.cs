using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // el gamemanager controla las variables que no se relacionan con otros gameobjects del juego 
    public enum GameManagerVariables { TIME, POINTS }; // esto sirve para facilitar la lectura del codigo 

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
    // Getter sirve para obtener las cosas 
    public int GetPoints()
    {
        return points ; 
    }
    // setter
    public void SetPoints(int value)
    {
        points = value; 

    }
    // callback---> funcion que se va a llamar en el onclick de los botones 
    public void LoadScene (string sceneName)
    {

        SceneManager.LoadScene(sceneName);
       AudioManager.instance.ClearAudios(); // esto nos ayuda a limpiar el audio anterior 
    }

    public void ExitGame () 
    {
        Debug.Log("Exit!!");
        Application.Quit();
    }
}
