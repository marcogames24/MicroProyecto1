using UnityEngine;

public class DamageDealer : MonoBehaviour
{
  
    public int damageAmount = 1; // Cantidad de daño que este objeto ocasionará
    public bool destroyAfterDamage = false; // Si el objeto (ej. trampa) se destruye tras causar daño

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que colisiona es el jugador
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            // Causa daño al jugador
            playerHealth.TakeDamage(damageAmount);
            Debug.Log(gameObject.name + " causó " + damageAmount + " de daño al jugador.");

            // Si está configurado, destruye el objeto después de causar daño
            if (destroyAfterDamage)
            {
                Destroy(gameObject);
            }
        }
    }
}




