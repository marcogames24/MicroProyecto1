using UnityEngine;
using UnityEngine.SceneManagement;
public class Level3VictorySystem : MonoBehaviour
{
    public GameObject victoryPanel;
    private bool isVictoryTriggered = false; // Verifica si ya se activó la victoria
    public GameObject BoatPrefab; //Este gameobject hace referencia al bote que en este caso actua como la
                                  //meta final del nivel del nivel3
    
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
    private void OnTriggerEnter(Collider other) //Aqui su funcion es que cuando el jugador colisione con el prefab boat
        //que representa la meta aparezca el panel de victoria indicando que gano la partida y el juego
    {
   
        if (other.CompareTag("Player")) 
    {
            TriggerVictory();
    }

    }

    public void QuitGame()// como es el nivel final aqui se asignara un solo boton que es de salir del juego.
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Cierra la aplicación (solo funciona en una build)
    }
}
