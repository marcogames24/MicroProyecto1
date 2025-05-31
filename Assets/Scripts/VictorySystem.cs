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

    public void NextLevel2()// Este método esta orientado para el nivel1 del juego//
                            //en la victory panel del nivel 1 cuando el jugador quiera presionar el botón de
                            //avanzar nivel //este se encargara de cargar al nivel 2 del juego 
    {
        SceneManager.LoadScene("Level2 IceZone"); //Carga la escena donde se desarrolla el nivel2 del juego
        Debug.Log("Cargando el nivel2 IceZone");//Un mensaje para verificar que el codigo esta funcionando
    }
    public void NextLevel3()// Este método esta orientado para el nivel2 del juego//
                            //en la victory panel del nivel 2 cuando el jugador quiera presionar el botón de
                            //avanzar nivel este se encargara de cargar al nivel 3 del juego 
    {
        SceneManager.LoadScene("Final Zone"); //Carga la escena donde se desarrolla el nivel3 del juego
        Debug.Log("Cargando el último nivel FinalZone");//Un mensaje para verificar que el codigo esta funcionando
    }
}


