using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    public int points = 1;
    private int totalPoints;
    public AudioClip coinClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MarioScript>())
        {
            Destroy(gameObject); 
            totalPoints = GameManager.instance.GetPoints(); // para que se consigan los puntos 
            totalPoints = points + totalPoints; // para que se vayan sumando 
            GameManager.instance.SetPoints(totalPoints); // para que aparezcan todos los puntos 
            AudioManager.instance.PlayAudio(coinClip, "coinSound"); // con esto le ponemos el sonido de la moneda
        }
    }
}

