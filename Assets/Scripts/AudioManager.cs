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
        audioObject.transform.SetParent(transform); // esto es para tenerlo organizado y que todos los objetos de audio que se vayam creando sean hijos del audiomanager
        AudioSource audioSourceComponent = audioObject.AddComponent<AudioSource>(); // con esto añadimos el componente audiosource
        audioSourceComponent.clip = audioClip;  //asignamos el clip al componente este clip es el que recibe 
        audioSourceComponent.loop = isLoop;    // asignamos el loop al componente 
        audioSourceComponent.volume = volume;  // asignamos el volumen al componente 
        audioSourceComponent.Play(); // esto es para que empice el audio 
        audioList.Add(audioObject); // añade un objeto a la lista para hacer un segumiento 
        if(!isLoop) // si el audio no esta en loop espero a que el audio acabe para destruirlo
        {
            StartCoroutine(WaitAudioEnd(audioSourceComponent));
        }
        
        return audioSourceComponent; // para dar libertad a los usuarios de nuestro componente 
    }

    IEnumerator WaitAudioEnd(AudioSource audioSource) // el ienumerator es una corrutina que tiene unity para simular que crea hilos y procesos y no pausa la ejecucion del programa 
    {
        while(audioSource && audioSource.isPlaying) // esperamos a que el audio deje de sonar para destruirlo 
        {
            yield return null; // esto le devuelve el control a unity 
        }
        Destroy (audioSource.gameObject);
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
