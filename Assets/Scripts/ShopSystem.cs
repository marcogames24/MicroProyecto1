using UnityEngine;
using UnityEngine.UI;
public class ShopSystem : MonoBehaviour
{
 
    public int playerCoins = 0; // Monedas recolectadas por el jugador
    [SerializeField] private InventorySystem inventorySystem; // Referencia al sistema de inventario
    [SerializeField] private Text coinText; // Texto que muestra las monedas

    void Start()
    {
        UpdateCoinsUI(); // Inicializa el texto con las monedas actuales
    }

    // **Nuevo m�todo para a�adir monedas**
    public void AddCoins(int amount)
    {
        playerCoins += amount; // Incrementa las monedas del jugador
        UpdateCoinsUI(); // Actualiza el texto de las monedas
        Debug.Log($"Monedas recolectadas: {playerCoins}");
    }

    public void BuyItem(GameObject button)
    {
        // Obtener el nombre del objeto desde el bot�n
        string itemName = button.name;

        // Obtener el precio del objeto desde su hijo "PriceText"
        Transform priceTextTransform = button.transform.Find("PriceText");
        if (priceTextTransform != null)
        {
            string priceText = priceTextTransform.GetComponent<Text>().text;

            if (int.TryParse(priceText, out int itemPrice)) // Validar formato correcto
            {
                // Verificar si el jugador tiene suficientes monedas
                if (playerCoins >= itemPrice)
                {
                    playerCoins -= itemPrice; // Deduce las monedas del jugador
                    inventorySystem.AddItem(itemName); // A�adir el objeto al inventario
                    UpdateCoinsUI(); // Actualiza el texto de las monedas
                    Debug.Log($"Has comprado {itemName} por {itemPrice} monedas. Monedas restantes: {playerCoins}");
                }
                else
                {
                    Debug.Log("No tienes suficientes monedas para comprar este objeto.");
                }
            }
            else
            {
                Debug.LogError($"El texto del precio ('{priceText}') no tiene un formato num�rico v�lido.");
            }
        }
        else
        {
            Debug.LogError("No se pudo encontrar el texto del precio en el bot�n.");
        }
    }

    private void UpdateCoinsUI()
    {
        if (coinText != null)
        {
            coinText.text = $"Coins: {playerCoins}"; // Actualiza el texto din�micamente
        }
        else
        {
            Debug.LogWarning("No se ha asignado el texto de monedas en el Inspector.");
        }
    }
}














