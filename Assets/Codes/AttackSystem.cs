using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    //public Animator animator;//Referencia al animador de la animación de ataque
    //public Rigidbody rb; //Referencia al rigibody del Character
    //public int CharacterDamage = 0; //Referencia al daño que el jugador le ocasionara a los jefes

    //private void Update()
    //{
    //    Collider
    //}


    //public Animator animator; //Referencia al animador de la animación de ataque
    //private bool isFacingRight = true; // Dirección inicial del personaje (mirando a la derecha)

    //private void Update()
    //{
    //    // Aqui verifica si se presiona la tecla z para realizar el ataque 
    //    if (Input.GetKeyDown(KeyCode.Z))
    //    {
    //        PerformAttack();
    //    }
    //}

    //public void UpdateDirection(float horizontalInput)
    //{
    //    // Actualiza la dirección del personaje según la entrada horizontal, como hay 2 animaciones dependiendo la dirección del personaje
    //    //este se enfocara cuando ataque en el lado derecho, y de no ser el caso se enfocara en el lado izquierdo 
    //    if (horizontalInput > 0)
    //    {
    //        isFacingRight = true;
    //    }
    //    else if (horizontalInput < 0)
    //    {
    //        isFacingRight = false;
    //    }
    //}

    //private void PerformAttack()//Aqui es donde se activa la animación de ataque dependiendo de la direccion actual del Character
    //{
       
    //    if (isFacingRight)
    //    {
    //        animator.SetTrigger("AttackRight"); // Activar animación de ataque a la derecha
    //    }
    //    else
    //    {
    //        animator.SetTrigger("AttackLeft"); // Activar animación de ataque a la izquierda
    //    }
    //}
    
    public Animator animator; // Referencia al Animator del personaje
    public float horizontalInput; // Entrada horizontal del movimiento
    private bool isFacingRight = true; // Dirección inicial del personaje (mirando a la derecha)


    private void Update()
    {
        // Detecta si se presiona la tecla Z para atacar
        if (Input.GetKeyDown(KeyCode.O))
        {
            PerformAttack();
        }

    }

    public void UpdateDirection(float horizontalInput)
    {
        // Actualiza la dirección del personaje según la entrada horizontal
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
        // Activa la animación de ataque según la dirección actual
        if (isFacingRight)
        {
            animator.SetTrigger("AttackRight"); // Activar animación de ataque a la derecha
        }
        else
        {
            animator.SetTrigger("AttackLeft"); // Activar animación de ataque a la izquierda
        }
    }
}






