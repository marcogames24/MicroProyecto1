using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic; // Esto es lo que falta


public class PlayerInventory : MonoBehaviour
{

    public int coinCount = 0; // Contador de monedas
    public int maxCoins = 3; // L�mite de monedas
    public Text coinText; // Elemento UI para mostrar las monedas
    public List<string> inventory = new List<string>(); // Inventario para objetos recolectados
    public int maxInventorySize = 3; // L�mite de objetos en el inventario

    private void Update()
    {
        // Actualiza la interfaz con el n�mero de monedas
        coinText.text = "Monedas: " + coinCount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin")) // Si es una moneda
        {
            if (coinCount < maxCoins) // Si no alcanz� el l�mite
            {
                coinCount++;
                Destroy(other.gameObject); // Elimina la moneda de la escena
            }
            else
            {
                Debug.Log("Ya tienes el m�ximo de monedas.");
            }
        }

        if (other.CompareTag("HealingItem")) // Si es un objeto sanador
        {
            if (inventory.Count < maxInventorySize) // Si hay espacio en el inventario
            {
                inventory.Add(other.name); // A�ade el objeto al inventario
                Destroy(other.gameObject); // Elimina el objeto de la escena
                Debug.Log("Recogido: " + other.name);
            }
            else
            {
                Debug.Log("El inventario est� lleno.");
            }
        }
    }
}


