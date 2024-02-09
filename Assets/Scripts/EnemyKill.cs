using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    public int points = 1;
    private int totalPoints;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<MarioScript>() )
        {
            Destroy(transform.parent.gameObject ); // con el parent podemos destruir el goomba ya que el collider puesto para su destruccion es el del hijo
            totalPoints = GameManager.instance.GetPoints(); // para que se consigan los puntos 
            totalPoints = points + totalPoints; // para que se vayan sumando 
            GameManager.instance.SetPoints(totalPoints); // para que aparezcan todos los puntos 
        }
    }
}
