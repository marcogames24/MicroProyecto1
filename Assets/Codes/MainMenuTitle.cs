using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuTitle : MonoBehaviour
{
   
    public AudioSource backgroundMusic; // Referencia al audio de fondo

    void Start()
    {
        // Comienza a reproducir la m�sica de fondo
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }
        else
        {
            Debug.LogWarning("No se ha asignado m�sica de fondo al men�.");
        }
    }

    // M�todo para el bot�n de iniciar el juego
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // Carga a la escena donde se desarrolla el juego
        Debug.Log("�Comenzando el juego!");
    }

    // M�todo para el bot�n de salir del juego
    public void QuitGame()
    {
        Debug.Log("�Saliendo del juego!");
        Application.Quit(); // Funciona en una build, no en el editor
    }
}


