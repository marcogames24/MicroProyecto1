using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class NewCharacterMovement : MonoBehaviour
{

    public float moveSpeed = 5f; // Velocidad de movimiento
    public Rigidbody rb; // Referencia al Rigidbody del personaje
    public Animator animator; // Referencia al Animator del personaje

    private Vector3 movement;//esta variable nos ayudara a controlar el movimiento del personaje en el espacio 3d
    private float lastHorizontalDirection = 1; // esto hace referencia a la direccion en la que se encuentra el jugador
                                               //actualmente
    
    float CharacterOriginalScaleX; //Como queremos que el personaje mantenga su escala en pantalla lo que hacemos aqui 
                                   //es que creamos esta varibale para que cuando cambie de dirección solo el la posición en X cambie y el sprite lo haga también

    private SpriteRenderer spriteRenderer;

    private void Start()
    {

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Movement();
        FlipSprite();

       
    }
    void FixedUpdate()
    {
        // Aplica movimiento normalizado en los ejes X y Z
        Vector3 move = movement.normalized * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }
    void Movement() 
    {

        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        Object.FindFirstObjectByType<AttackSystem>().UpdateDirection(movement.x);
        //este apartado tiene relacion con el codigo
        //implementado AttackSystem esto permitira que el juador cuando presione la tecla O este realice las animaciones de ataque 
        //eso si el truco es que cuando se mueve a la izqueirda y sueltes la direccion si te quedaste en la izquerida el ataque izquierdo 
        //se realizara, tambien aplca en la direccion de la derecha.

        bool isMoving = movement.magnitude > 0; // Si hay movimiento, es verdadero

        // Activar o desactivar la animación en el Animator
        animator.SetBool("IsMoving", isMoving);

        float speed = movement.magnitude; // Calcula velocidad del personaje
        animator.SetFloat("Speed", speed); // Controla el Blend Tree en el Animator

        animator.SetFloat("HorizontalDirection", lastHorizontalDirection);
    }
    void FlipSprite() 
    {


        if (movement.x > 0)
        {

            //  lastHorizontalDirection = 1;//aqui quiere decir que si se realiza el movimiento en la derecha es la dirección donde
            //se movera el personaje

            spriteRenderer.flipX = false;

        }
        else if (movement.x < 0)

        {
            //lastHorizontalDirection = -1;//aqui quiere decir que si se realiza el movimiento en el lado opuesto el sprite cambia a izquierdo

            spriteRenderer.flipX = true;
        }

                                                                                                             //se mueve su sprite cambia de estar en positivo , que es el lado derecho, a negativo que es el lado izquierdo
        



    }

}
