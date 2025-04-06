using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
 
    public HealingItem healingItem; // Referencia al objeto sanador que representa este �tem
    private Button button; // Bot�n del inventario para detectar clics

    private void Start()
    {
        // Configura el bot�n para detectar clics
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnItemClicked); // Agrega la funci�n al clic del bot�n
        }
        else
        {
            Debug.LogWarning("No se encontr� el componente Button en el �tem del inventario.");
        }
    }

    public void OnItemClicked()
    {
        // Encuentra al jugador y aplica la curaci�n usando el m�todo recomendado
        PlayerHealth playerHealth = FindFirstObjectByType<PlayerHealth>();
        if (healingItem != null && playerHealth != null)
        {
            healingItem.Use(playerHealth); // Usa el objeto sanador
            Debug.Log($"Usaste un objeto del inventario: {healingItem.name}");
        }
        else
        {
            Debug.LogWarning("No se pudo usar el objeto. Aseg�rate de que est� correctamente configurado.");
        }
    }
}




