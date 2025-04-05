using UnityEngine;

public class ShopSystem : MonoBehaviour
{
 
    public int playerCoins = 10; // Monedas iniciales del jugador
    [SerializeField] private InventorySystem inventorySystem; // Referencia al sistema de inventario
    public void BuyItem(GameObject button)
    {
        // Obtener el nombre del objeto desde el botón
        string itemName = button.name;

        // Obtener el precio del objeto desde su hijo "PriceText"
        Transform priceTextTransform = button.transform.Find("PriceText");
        if (priceTextTransform != null)
        {
            string priceText = priceTextTransform.GetComponent<UnityEngine.UI.Text>().text;

            if (int.TryParse(priceText, out int itemPrice)) // Validar formato correcto
            {
                // Verificar si el jugador tiene suficientes monedas
                if (playerCoins >= itemPrice)
                {
                    playerCoins -= itemPrice; // Deduce las monedas del jugador
                    inventorySystem.AddItem(itemName); // Añadir el objeto al inventario
                    Debug.Log($"Has comprado {itemName} por {itemPrice} monedas. Monedas restantes: {playerCoins}");
                }
                else
                {
                    Debug.Log("No tienes suficientes monedas.");
                }
            }
            else
            {
                Debug.LogError($"El texto del precio ('{priceText}') no tiene un formato numérico válido.");
            }
        }
        else
        {
            Debug.LogError("No se pudo encontrar el texto del precio en el botón.");
        }
    }

}







