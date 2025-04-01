using UnityEngine;

public class DamageDealer : MonoBehaviour
{
  
    public int damageAmount = 1; // Cantidad de da�o que este objeto ocasionar�
    public bool destroyAfterDamage = false; // Si el objeto (ej. trampa) se destruye tras causar da�o

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que colisiona es el jugador
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            // Causa da�o al jugador
            playerHealth.TakeDamage(damageAmount);
            Debug.Log(gameObject.name + " caus� " + damageAmount + " de da�o al jugador.");

            // Si est� configurado, destruye el objeto despu�s de causar da�o
            if (destroyAfterDamage)
            {
                Destroy(gameObject);
            }
        }
    }
}




