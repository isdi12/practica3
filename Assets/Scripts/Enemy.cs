using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float speed ;
    public Transform Pepe;
    private SpriteRenderer _rend;
    public GameObject Restart;
    public Image GameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        Pepe = FindAnyObjectByType<MarioScript>().transform;
        GameOver.enabled = false;
        Restart.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if (Pepe !=null) // para asegurarnos de que la variable transform no sea nula
        {
            if(transform.position.x < Pepe.position.x) //Compara las posiciones en el eje x y mueve a Pingu hacia Pepe
            {
                transform.Translate(Vector2.right * speed *  Time.deltaTime);
                _rend.flipX = false;
            }
            // si la posicion de pingu es menor que la de pepe mueve a pingu hacia la derecha
            else if (transform.position.x > Pepe.position.x)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                _rend.flipX = true;
            }
            // si la posicion de pingu es menor que la de pepe mueve a pingu hacia la izquierda
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DeathZone>()) 
        { 
            Destroy(gameObject);
            Restart.gameObject.SetActive(true);
            GameOver.enabled = true;
        }
    }              
}
