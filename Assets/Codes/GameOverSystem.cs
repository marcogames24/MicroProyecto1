using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSystem : MonoBehaviour
{

    public int fallThreshold = -10; // Altura de caída que activa la pantalla de derrota
    public GameObject defeatPanel; // Panel de derrota (Canvas)
    public PlayerHealth playerHealth; // Referencia al script PlayerHealth

    private bool isGameOver = false;

    void Start()
    {
        // Asegurarse de que la pantalla de derrota esté oculta al inicio
        defeatPanel.SetActive(false);
    }

    void Update()
    {
        // Verificar si el jugador cae por debajo del umbral
        if (transform.position.y < fallThreshold && !isGameOver)
        {
            TriggerGameOver();
        }

        // Verificar si el jugador ha perdido todas las vidas
        if (playerHealth.currentHealth <= 0 && !isGameOver)
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        isGameOver = true; // Marcar que el juego ha terminado
        Time.timeScale = 0; // Detener el tiempo
        defeatPanel.SetActive(true); // Mostrar el panel de derrota
        Debug.Log("¡Juego Terminado! El jugador ha perdido.");
    }

    // Botón para reiniciar el nivel
    public void RestartLevel()
    {
        Time.timeScale = 1; // Restaurar el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reiniciar la escena actual
    }

    // Botón para salir del juego
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Salir del juego (solo funciona en una build)
    }
}


