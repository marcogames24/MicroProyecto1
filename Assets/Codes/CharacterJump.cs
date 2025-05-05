using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    
    public float jumpForce = 5f; // Fuerza del salto
    private Rigidbody rb; // Referencia al Rigidbody del personaje
    private Animator animator; // Referencia al Animator
    private bool isFacingRight = true; // Dirección del personaje

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        if (rb == null) Debug.LogError("El personaje no tiene Rigidbody.");
        if (animator == null) Debug.LogError("El personaje no tiene Animator.");
    }
    void Jump()
    {
        if (rb != null)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // Activar la animación de salto según la dirección
            if (isFacingRight)
            {
                animator.SetTrigger("JumpRight"); // Cambiamos a SetTrigger
                animator.ResetTrigger("JumpLeft"); // Evita conflictos
                Debug.Log("JumpRight activado");
            }
            else
            {
                animator.SetTrigger("JumpLeft"); // Cambiamos a SetTrigger
                animator.ResetTrigger("JumpRight"); // Evita conflictos
                Debug.Log("JumpLeft activado");
            }

            // Activar el trigger de salto
            animator.SetTrigger("JumpTrigger");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Jump();
        }

        // Solo desactivar la animación de salto cuando el personaje ha aterrizado completamente
        if (rb.linearVelocity.y == 0)
        {
            animator.ResetTrigger("JumpTrigger"); // Resetea el trigger para evitar activaciones repetidas
        }
    }
}




