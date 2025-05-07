using UnityEngine;

public class FlyingEnemyAI : MonoBehaviour
{
   
    public Transform player; // Referencia al personaje (transform del jugador)
    public float detectionRadius = 5f; // Radio de detección del enemigo
    public float moveSpeed = 2f; // Velocidad de movimiento hacia el jugador

    private void Update()
    {
        // Calcula la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si el jugador está dentro del radio de detección
        if (distanceToPlayer <= detectionRadius)
        {
            // Mueve al enemigo hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}




