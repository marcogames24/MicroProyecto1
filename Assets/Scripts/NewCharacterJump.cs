using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class NewCharacterJump : MonoBehaviour
{
    public float jumpForce = 5f; // Fuerza del salto
    public Rigidbody rb; // Referencia al Rigidbody del personaje
    public Animator animator; // Referencia al Animator
    private bool isJumping = true; // Dirección del personaje
    private float lastHorizontalDirection = 1; // esto hace referencia a la direccion en la que se encuentra el jugador
                                               //actualmente
    float CharacterOriginalScaleX; //Como queremos que el personaje mantenga su escala en pantalla lo que hacemos aqui 
                                             //es que creamos esta varibale para que cuando cambie de dirección solo el la posición en X cambie y el sprite lo haga también
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        if (rb == null) Debug.LogError("El personaje no tiene Rigidbody.");
        if (animator == null) Debug.LogError("El personaje no tiene Animator.");
    }

    void Update()
    {
        // Detectar entrada de salto
        if (Input.GetKeyDown(KeyCode.P) && !isJumping)
        {
            Jump();
        }

        // Verificar si el personaje está cayendo para resetear el estado de salto
        if (isJumping && rb.linearVelocity.y < 0)
        {
            animator.SetBool("IsJumping", false);
            isJumping = false;
        }
        float verticalVelocity = rb.linearVelocity.y;
        animator.SetFloat("VerticalVelocity", verticalVelocity);

        // Activar la animación de salto cuando el personaje empieza a subir
        if (verticalVelocity > 0)
        {
            animator.SetBool("IsJumping", true);
        }

        // Volver al estado normal cuando el personaje aterriza
        if (Mathf.Approximately(rb.linearVelocity.y, 0))
        {
            animator.SetBool("IsJumping", false);
        }

      //  transform.localScale = new Vector3(lastHorizontalDirection * CharacterOriginalScaleX, transform.localScale.y, transform.localScale.z);

    }

    void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        animator.SetBool("IsJumping", true);

        // Aplicar dirección al personaje sin afectar el sprite
      //  transform.localScale = new Vector3(lastHorizontalDirection * CharacterOriginalScaleX, transform.localScale.y, transform.localScale.z);
    }



}
