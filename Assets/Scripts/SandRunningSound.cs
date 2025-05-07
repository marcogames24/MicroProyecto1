using UnityEngine;

public class SandRunningSound : MonoBehaviour
{
 
    public AudioSource audioSource; // Componente de sonido
    public AudioClip footstepClip; // Sonido de pisadas
    public Animator animator; // Referencia al Animator del personaje

    private void Update()
    {
        // Comprueba si el personaje est� corriendo hacia la izquierda o la derecha
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Character Run") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("Character Run Left"))
        {
            if (!audioSource.isPlaying)
            {
                // Reproduce el sonido de pisadas si no est� ya reproduci�ndose
                audioSource.clip = footstepClip;
                audioSource.loop = true; // Loopea mientras el personaje corre
                audioSource.Play();
            }
        }
        else
        {
            // Detiene el sonido si el personaje no est� corriendo
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}




