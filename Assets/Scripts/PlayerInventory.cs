using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic; // Esto es lo que falta


public class PlayerInventory : MonoBehaviour
{

    public int coinCount = 0; // Contador de monedas
    public int maxCoins = 3; // Límite de monedas
    public Text coinText; // Elemento UI para mostrar las monedas
    public List<string> inventory = new List<string>(); // Inventario para objetos recolectados
    public int maxInventorySize = 3; // Límite de objetos en el inventario

    private void Update()
    {
        // Actualiza la interfaz con el número de monedas
        coinText.text = "Monedas: " + coinCount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin")) // Si es una moneda
        {
            if (coinCount < maxCoins) // Si no alcanzó el límite
            {
                coinCount++;
                Destroy(other.gameObject); // Elimina la moneda de la escena
            }
            else
            {
                Debug.Log("Ya tienes el máximo de monedas.");
            }
        }

        if (other.CompareTag("HealingItem")) // Si es un objeto sanador
        {
            if (inventory.Count < maxInventorySize) // Si hay espacio en el inventario
            {
                inventory.Add(other.name); // Añade el objeto al inventario
                Destroy(other.gameObject); // Elimina el objeto de la escena
                Debug.Log("Recogido: " + other.name);
            }
            else
            {
                Debug.Log("El inventario está lleno.");
            }
        }
    }
}


