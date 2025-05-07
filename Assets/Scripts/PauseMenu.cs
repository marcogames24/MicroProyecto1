using UnityEngine;

public class PauseMenu : MonoBehaviour
{
  
    [SerializeField] private GameObject Pausemenu; // Referencia al menú de pausa
    private bool isPaused = false; // Estado del juego (pausado o no)

    void Update()
    {
        // Verifica si se presiona la tecla Enter
        if (Input.GetKeyDown(KeyCode.Return)) //El botón de teclado Enter se encargara de pausar el juego y que aparezca el menu de pausa
        {
            TogglePause(); // Alterna entre pausa y reanudar
        }
    }

    public void TogglePause() //Se encargara de que se pueda visualizar la pantalla del menu de pausa
    {
        if (isPaused)
        {
            // Reanuda el juego
            Time.timeScale = 1f;
            Pausemenu.SetActive(false);
            isPaused = false;
        }
        else
        {
            // Pausa el juego
            Time.timeScale = 0f;
            Pausemenu.SetActive(true);
            isPaused = true;
        }
    }

    public void Continue()//Este esta enfocado para el boton de continue del menu pausa para reanudar la partida donde lo dejo el jugador
    {
        
        Time.timeScale = 1f;
        Pausemenu.SetActive(false);
        isPaused = false;
    }

    public void Quit()//Este apartado es para que caundo el jugador ya no desee seguir jugando al presionar el Quit este saldra de la partida,
                      //esto es mas visible en el ejecutable del juego.
    {
        
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }
}


