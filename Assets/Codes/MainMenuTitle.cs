using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuTitle : MonoBehaviour
{
   
    public AudioSource backgroundMusic; // Referencia al audio de fondo

    void Start()
    {
        // Comienza a reproducir la música de fondo
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }
        else
        {
            Debug.LogWarning("No se ha asignado música de fondo al menú.");
        }
    }

    // Método para el botón de iniciar el juego
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // Carga a la escena donde se desarrolla el juego
        Debug.Log("¡Comenzando el juego!");
    }

    // Método para el botón de salir del juego
    public void QuitGame()
    {
        Debug.Log("¡Saliendo del juego!");
        Application.Quit(); // Funciona en una build, no en el editor
    }
}


