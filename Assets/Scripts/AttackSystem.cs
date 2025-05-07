using UnityEngine;

public class AttackSystem : MonoBehaviour
{
   
    public Animator animator; // Referencia al Animator del personaje
    public float horizontalInput; // Entrada horizontal del movimiento
    private bool isFacingRight = true; // Direcci�n inicial del personaje (mirando a la derecha)


    private void Update()
    {
        // Detecta si se presiona la tecla O para atacar
        if (Input.GetKeyDown(KeyCode.O))
        {
            PerformAttack();
        }

    }

    public void UpdateDirection(float horizontalInput)
    {
        // Actualiza la direcci�n del personaje seg�n la entrada horizontal
        this.horizontalInput = horizontalInput; // Guarda la entrada horizontal

        if (horizontalInput > 0)
        {
            isFacingRight = true;
        }
        else if (horizontalInput < 0)
        {
            isFacingRight = false;
        }
    }

    private void PerformAttack()
    {
        // Activa la animaci�n de ataque seg�n la direcci�n actual
        if (isFacingRight)
        {
            animator.SetTrigger("AttackRight"); // Activar animaci�n de ataque a la derecha
        }
        else
        {
            animator.SetTrigger("AttackLeft"); // Activar animaci�n de ataque a la izquierda
        }
    }
}






