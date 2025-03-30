using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f; // Velocidad de movimiento
    public Rigidbody rb; // Referencia al Rigidbody del personaje
    public Animator animator; // Referencia al Animator del personaje

    private Vector3 movement;
    private float lastHorizontalDirection = 1; // 1 para derecha, -1 para izquierda

    void Update()
    {
        // Captura la entrada de las teclas ASWD
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        // Actualizar la dirección horizontal si hay movimiento en X
        if (movement.x > 0)
        {
            lastHorizontalDirection = 1; // Derecha
        }
        else if (movement.x < 0)
        {
            lastHorizontalDirection = -1; // Izquierda
        }

        // Actualizar parámetros del Animator
        if (movement.z != 0)
        {
            // Si se mueve arriba o abajo, usa la dirección horizontal previa
            animator.SetFloat("MoveX", lastHorizontalDirection);
            animator.SetFloat("MoveZ", 0);
        }
        else
        {
            // Usa la dirección actual
            animator.SetFloat("MoveX", movement.x);
            animator.SetFloat("MoveZ", movement.z);
        }

        // Verifica si el personaje está en movimiento
        animator.SetBool("IsMoving", movement != Vector3.zero);
    }

    void FixedUpdate()
    {
        // Aplica movimiento normalizado en los ejes X y Z
        Vector3 move = movement.normalized * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }
}



   


 



