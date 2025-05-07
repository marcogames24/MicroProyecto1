using UnityEngine;

public class ShopSignInteraction : MonoBehaviour
{
  
    public GameObject shopUI; // Referencia al Canvas de la tienda
    private bool isPlayerNearby = false; // Verifica si el jugador está cerca
    private bool isShopOpen = false; // Verifica si la tienda está abierta

    void Update()
    {
        // Detectar interacción si el jugador está cerca y presiona la tecla E
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ToggleShop(); // Mostrar u ocultar la tienda
        }
    }

    void ToggleShop()
    {
        // Cambiar el estado de la tienda
        isShopOpen = !isShopOpen;
        shopUI.SetActive(isShopOpen); // Mostrar u ocultar el Canvas de la tienda

        // Pausar el juego mientras la tienda está abierta
        if (isShopOpen)
        {
            Time.timeScale = 0; // Pausar el tiempo
            Debug.Log("La tienda está abierta. Presiona E para salir.");
        }
        else
        {
            Time.timeScale = 1; // Restaurar el tiempo
            Debug.Log("La tienda está cerrada.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en el trigger es el jugador
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true; // Marca que el jugador está cerca
            Debug.Log("Presiona E para interactuar con la tienda.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verificar si el objeto que sale del trigger es el jugador
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false; // Marca que el jugador ya no está cerca
            Debug.Log("Te alejaste de la tienda.");
        }
    }
}




