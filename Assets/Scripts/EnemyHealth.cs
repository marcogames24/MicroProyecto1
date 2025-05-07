using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 2; // Vida máxima del enemigo , por supuesto es la que definiremos para los otros enemigos del juego
    private int currentHealth; // Vida actual del enemigo

    void Start()
    {
        // Inicializa la vida del enemigo
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) // Se encarga de el manejo de vida del enemigo al que le agreguemos el codigo
    {
        // Reduce la vida del enemigo
        currentHealth -= damage;

        // Verifica si la vida llegó a 0 o menos
        if (currentHealth <= 0)
        {
            Die(); // Llama al método para manejar la muerte
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " ha muerto.");
        Destroy(gameObject); // Elimina el enemigo del juego cuando todas sus vidas llegan a 0
    }
}


