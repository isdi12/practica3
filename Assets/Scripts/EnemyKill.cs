using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<MarioScript>() )
        {
            Destroy(transform.parent.gameObject ); // con el parent podemos destruir el goomba ya que el collider puesto para su destruccion es el del hijo
        }
    }
}
