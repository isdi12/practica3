using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioScript : MonoBehaviour
{
    public KeyCode rightKey, leftKey, jumpKey;
    public float speed, jumpForce, rayDistance;
    public LayerMask groundMask; // mascara de colisiones con la que queremos que el rayo se pueda chocar 

    private Rigidbody2D rb;
    private SpriteRenderer _rend;
    private Animator _animator; // para las animaciones
    private Vector2 dir;
    private bool isJumping;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _rend = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        print(GameManager.instance.GetTime());

        dir = Vector2.zero;
        if (Input.GetKey(rightKey))
        {
            _rend.flipX = false;
            dir = Vector2.right;
        }
        else if (Input.GetKey(leftKey))
        {
            _rend.flipX = true;
            dir = new Vector2(-1, 0);
        }

        isJumping = false;
        if (Input.GetKey(jumpKey))
        {
            isJumping = true;
        }
        #region ANIMACIONES
        if (dir != Vector2.zero)
        {
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }

        #endregion
    }

    private void FixedUpdate()
    {
        bool grnd = IsGrounded();
        //if (dir != Vector2.zero)
        {

            float currentYVel = rb.velocity.y; // esto sirve para caer en la msima velocidad 
            Vector2 nVel = dir * speed;
            nVel.y = currentYVel;
            rb.velocity = nVel;
        }
        if (isJumping && grnd) // si el jugador tiene la intencion de saltar le añadiremos la fuerza 
        {
            _animator.Play("Jump");
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce * rb.gravityScale, ForceMode2D.Impulse); // añade una fuerza al riggidbody 
            isJumping = false;

        }
        _animator.SetBool("isGrounded", grnd);

    }

    private bool IsGrounded() // como nos tiene que devolver verdadero usamos un bool en el metodo
    {
        RaycastHit2D collision = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundMask); // lanza un rayo desde el centro del personaje hacia abajo el rayo llega hasta ray distance y solo va encontrar colisiones en la capa que definamos en groundmask
        if (collision) // si chocamos con lo deseado devolvera true si no false
        {
            return true;
        }

        return false;
    }

    private void OnDrawGizmos() // Este metodo es una guia de ayuda para ver la direccion del rayo
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance); // esto lo que nos permite es dibujar el rayo, se multiplica el vector por el escalar (raydistance) 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DeathZone>())
        {
            transform.position = new Vector2(-10.16f, -2.89f);

        }
    }
    
}
            
