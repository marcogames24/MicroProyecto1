using UnityEngine;

public class IceFloorDamage : MonoBehaviour
{
    public int damageFloor = 1; // Daño cada ciclo
    public float damageInterval = 120f; // Intervalo de daño en segundos (2 minutos)
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>(); //  Detecta automáticamente el script en el jugador

        if (playerHealth != null)
        {
            InvokeRepeating("ApplyColdDamage", damageInterval, damageInterval); //Aplica daño progresivo sin tocar `PlayerHealth`
        }
    }

    private void ApplyColdDamage()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageFloor); // Llama a `TakeDamage()` directamente en `PlayerHealth`
            Debug.Log("El jugador pierde vida por frío. Vida actual: " + playerHealth.currentHealth);
        }
    }

}
