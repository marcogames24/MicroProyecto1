using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 10; // Vida máxima del jefe
    private int currentHealth; // Vida actual del jefe
    public GameObject victoryPanel; // Panel de victoria (Canvas)

    private bool isDefeated = false; // Verifica si el jefe ya ha sido derrotado

    void Start()
    {
        // Inicializa la salud del jefe
        currentHealth = maxHealth;
        victoryPanel.SetActive(false); // Asegúrate de que la pantalla de victoria esté oculta al inicio
    }

    public void TakeDamage(int damage)
    {
        if (isDefeated) return; // No hace nada si el jefe ya ha sido derrotado

        // Reduce la salud
        currentHealth -= damage;

        Debug.Log($"El jefe recibió {damage} de daño. Vida restante: {currentHealth}");

        // Verifica si la salud llega a cero o menos
        if (currentHealth <= 0)
        {
            Die(); // Llama al método para manejar la derrota del jefe
        }
    }

    private void Die()
    {
        isDefeated = true; // Marca que el jefe fue derrotado
        Debug.Log(gameObject.name + " ha sido derrotado.");
        TriggerVictory(); // Activa la pantalla de victoria
        Destroy(gameObject); // Elimina al jefe del juego
    }

    private void TriggerVictory()
    {
        Time.timeScale = 0; // Detiene el tiempo del juego
        victoryPanel.SetActive(true); // Muestra el panel de victoria
        Debug.Log("¡Victoria! El jugador ha ganado al derrotar al jefe final.");
    }

    // Detectar colisiones con el ataque del jugador
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que golpea tiene el componente CharacterDamage
        CharacterDamage characterDamage = other.GetComponent<CharacterDamage>();
        if (characterDamage != null)
        {
            TakeDamage(characterDamage.attackDamage); // Aplica daño al jefe
            Debug.Log($"El jefe fue golpeado por el jugador. Daño recibido: {characterDamage.attackDamage}");
        }
    }
}

    




