using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    private List<GameObject> audioList; 
    // Start is called before the first frame update
    void Awake()
    {
        if (!instance) // si instance no tiene informacion 
        {
            instance = this; // instance se asigna a este objeto 
            DontDestroyOnLoad(gameObject); // se indica que este obj no se destruya con la carga de escenas 
        }
        else // si instance tiene info 
        {
            Destroy(gameObject); // se destruye el gameObject, para que no haya dos mas gamemanagers en el juego

        }
        audioList = new List<GameObject>();
    }
   
    public AudioSource PlayAudio (AudioClip audioClip, string gameObjectName, bool isLoop = false, float volume = 1.0f)
    {
        GameObject audioObject = new GameObject(gameObjectName); // declaramos el gameobject
        audioObject.transform.SetParent(transform); // esto es para tenerlo organizado y que todos los objetos de audio que se vayam creand sean hijos del audiomanager
        AudioSource audioSourceComponent = audioObject.AddComponent<AudioSource>(); // con esto añadimos el componente audiosource
        audioSourceComponent.clip = audioClip;  //asignamos el clip al componente este clip es el que recibe 
        audioSourceComponent.loop = isLoop;    // asignamos el loop al componente 
        audioSourceComponent.volume = volume;  // asignamos el volumen al componente 
        audioSourceComponent.Play(); // esto es para que empice el audio 
        audioList.Add(audioObject); // añade un objeto a la lista para hacer un segumiento 
        
        
        return audioSourceComponent; // para dar libertad a los usuarios de nuestro componente 
    }

    public void ClearAudios ()
    {
        foreach(GameObject audioObject in audioList) // el foreach nos ayuda a recorrer los elementos de una lista 
        {
            Destroy(audioObject);
        }

        audioList.Clear(); // esto es porque siempre se queda algo de memoria para que lo borre 
    }
}
