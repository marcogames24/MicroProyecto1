using UnityEngine;

public class IceFloorDamage : MonoBehaviour
{
    public int damageFloor = 0;//En la pantalla antes de la ejecucion se define cuanto da�o
                               //ocasiona el suelo al enemigo
    
    public float timeLapseDamage = 0f;// Esta variable se encargara de definir por cuanto
                                // tiempo el suelo le quitara vida
                                // al jugador , dando la sensaci�n de que esta
                                // perdiendo vida por hipotermia.

    private void OnTriggerEnter(Collider other)//Aqui definiremos como se aplicara el da�o del suelo al jugador
        
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

    }
}
