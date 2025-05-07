using UnityEngine;
using UnityEngine.SceneManagement;
public class VictorySystem : MonoBehaviour
{

    public GameObject victoryPanel; // Panel de victoria (Canvas)
    private bool isVictoryTriggered = false; // Verifica si ya se activ� la victoria

    void Start()
    {
        // Aseg�rate de que la pantalla de victoria est� oculta al inicio
        victoryPanel.SetActive(false);
    }

    // M�todo para activar la pantalla de victoria
    public void TriggerVictory()
    {
        if (!isVictoryTriggered)
        {
            isVictoryTriggered = true; // Marca que la victoria se activ�
            Time.timeScale = 0; // Pausa el juego
            victoryPanel.SetActive(true); // Muestra el panel de victoria
            Debug.Log("�Victoria! El jugador ha ganado al derrotar al jefe final.");
        }
    }

    // M�todo para reiniciar el nivel (bot�n del panel de victoria)
    public void RestartLevel()
    {
        Time.timeScale = 1; // Restaura el tiempo normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia el nivel actual
    }

    // M�todo para salir del juego (bot�n del panel de victoria)
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Cierra la aplicaci�n (solo funciona en una build)
    }
}


