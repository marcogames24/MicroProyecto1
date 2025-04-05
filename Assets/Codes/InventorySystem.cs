using UnityEngine;
using System.Collections.Generic; // Necesario para listas
public class InventorySystem : MonoBehaviour
{
  
    [SerializeField] private GameObject[] inventorySlots; // Referencia a las casillas del inventario
    private List<string> inventoryItems = new List<string>(); // Lista de objetos en el inventario
   
    [SerializeField] private Sprite freartSprite; // Sprite para FREART
    [SerializeField] private Sprite fruthingSprite; // Sprite para FRUTHING

    public void AddItem(string itemName)
    {
        // Comprueba si hay espacio en el inventario
        if (inventoryItems.Count < inventorySlots.Length)
        {
            inventoryItems.Add(itemName); // A�ade el objeto a la lista
            UpdateInventoryUI(); // Actualiza las casillas visualmente
        }
        else
        {
            Debug.Log("No hay espacio en el inventario.");
        }
    }

    private void UpdateInventoryUI()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < inventoryItems.Count)
            {
                inventorySlots[i].SetActive(true); // Activa la casilla
                var imageComponent = inventorySlots[i].GetComponentInChildren<UnityEngine.UI.Image>();
                if (imageComponent != null)
                {
                    // Cambiar la imagen del objeto. Aqu� debes asignar un Sprite seg�n el nombre del objeto.
                    imageComponent.sprite = GetItemSprite(inventoryItems[i]); // M�todo para obtener el Sprite basado en el nombre del objeto.
                }
                else
                {
                    Debug.LogError($"El slot {i} no tiene un componente Image.");
                }
            }
            else
            {
                inventorySlots[i].SetActive(false); // Desactiva la casilla si est� vac�a
            }
        }
    }

    // M�todo para obtener el Sprite correspondiente al objeto comprado
    private Sprite GetItemSprite(string itemName)
    {
        switch (itemName)
        {
            case "FREART":
                return freartSprite; // Aseg�rate de tener este Sprite definido en tu script.
            case "FRUTHING":
                return fruthingSprite; // Aseg�rate de tener este Sprite definido en tu script.
            default:
                Debug.LogError($"No se encontr� un Sprite para el objeto: {itemName}");
                return null;
        }
    }

}


