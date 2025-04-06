using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
 
    public HealingItem healingItem; // Referencia al objeto sanador que representa este ítem
    private Button button; // Botón del inventario para detectar clics

    private void Start()
    {
        // Configura el botón para detectar clics
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnItemClicked); // Agrega la función al clic del botón
        }
        else
        {
            Debug.LogWarning("No se encontró el componente Button en el ítem del inventario.");
        }
    }

    public void OnItemClicked()
    {
        // Encuentra al jugador y aplica la curación usando el método recomendado
        PlayerHealth playerHealth = FindFirstObjectByType<PlayerHealth>();
        if (healingItem != null && playerHealth != null)
        {
            healingItem.Use(playerHealth); // Usa el objeto sanador
            Debug.Log($"Usaste un objeto del inventario: {healingItem.name}");
        }
        else
        {
            Debug.LogWarning("No se pudo usar el objeto. Asegúrate de que está correctamente configurado.");
        }
    }
}




