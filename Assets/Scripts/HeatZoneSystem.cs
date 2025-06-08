using UnityEngine;

public class HeatZoneSystem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Detectar si el objeto vacio de la escena 
            //interactua con el jugador
        {
            other.GetComponent<IceFloorDamage>().SetSafeZone(true); // Desactivar el da�o del script 
            //IceFloorDamage 
            Debug.Log("El jugador est� en una zona de calor. Se detiene el da�o.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Si el jugador se aleja de la Zona de Calor volvera a recibir 
            //da�o de IceFloorDamage
        {
            other.GetComponent<IceFloorDamage>().SetSafeZone(false); // Reactivar el da�o
            Debug.Log("El jugador dej� la zona de calor. Se reactiva el da�o por fr�o.");
        }
    }

}
