using UnityEngine;

public class SpearProyectile : MonoBehaviour
{
    public int damage = 1;
    public LayerMask enemyLayer; // Asignar la capa de los enemigos

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("La lanza impact� contra: " + other.name); // Verifica si la colisi�n ocurre

        // Detectar si el objeto est� en la capa de enemigos
        if (((1 << other.gameObject.layer) & enemyLayer) != 0)
        {
            Debug.Log("Detectado como enemigo por LayerMask: " + other.name); // Confirma que est� en la capa correcta

            BossHealth enemyHealth = other.GetComponent<BossHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                Debug.Log("�Se aplic� da�o a " + other.name + "! Da�o infligido: " + damage);
            }
            else
            {
                Debug.Log("Error: " + other.name + " no tiene un componente EnemyHealth.");
            }

            // Desactivar la lanza solo si el enemigo recibi� da�o
            if (enemyHealth != null)
            {
                gameObject.SetActive(false);
            }
        }
    }


}
