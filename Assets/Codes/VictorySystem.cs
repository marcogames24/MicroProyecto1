using UnityEngine;
using UnityEngine.SceneManagement;
public class VictorySystem : MonoBehaviour
{

    public GameObject victoryPanel; // Panel de victoria (Canvas)
    private bool isVictoryTriggered = false; // Verifica si ya se activó la victoria

    void Start()
    {
        // Asegúrate de que la pantalla de victoria esté oculta al inicio
        victoryPanel.SetActive(false);
    }

    // Método para activar la pantalla de victoria
    public void TriggerVictory()
    {
        if (!isVictoryTriggered)
        {
            isVictoryTriggered = true; // Marca que la victoria se activó
            Time.timeScale = 0; // Pausa el juego
            victoryPanel.SetActive(true); // Muestra el panel de victoria
            Debug.Log("¡Victoria! El jugador ha ganado al derrotar al jefe final.");
        }
    }

    // Método para reiniciar el nivel (botón del panel de victoria)
    public void RestartLevel()
    {
        Time.timeScale = 1; // Restaura el tiempo normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia el nivel actual
    }

    // Método para salir del juego (botón del panel de victoria)
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Cierra la aplicación (solo funciona en una build)
    }
}


