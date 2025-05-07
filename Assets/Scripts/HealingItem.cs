using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public int healAmount; // Cantidad de corazones que este objeto recupera

    public void Use(PlayerHealth playerHealth)
    {
        if (playerHealth != null)
        {
            playerHealth.Heal(healAmount); // Recupera la vida del jugador
            Debug.Log($"El jugador ha recuperado {healAmount} corazones usando {gameObject.name}.");
        }
        else
        {
            Debug.LogWarning("No se encontró al jugador para aplicar la curación.");
        }
    }
}


