using UnityEngine;

public class HeatZoneSystem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Detectar si el objeto vacio de la escena 
            //interactua con el jugador
        {
            other.GetComponent<IceFloorDamage>().SetSafeZone(true); // Desactivar el daño del script 
            //IceFloorDamage 
            Debug.Log("El jugador está en una zona de calor. Se detiene el daño.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Si el jugador se aleja de la Zona de Calor volvera a recibir 
            //daño de IceFloorDamage
        {
            other.GetComponent<IceFloorDamage>().SetSafeZone(false); // Reactivar el daño
            Debug.Log("El jugador dejó la zona de calor. Se reactiva el daño por frío.");
        }
    }

}
