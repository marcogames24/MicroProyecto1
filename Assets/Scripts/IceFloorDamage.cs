using UnityEngine;

public class IceFloorDamage : MonoBehaviour
{
    public int damageFloor = 1; // Daño cada ciclo
    public float damageInterval = 120f; // Intervalo de daño en segundos (2 minutos)
    private PlayerHealth playerHealth;
    private bool isInHeatZone = false;//Esta varible sirve para que trabaje con el script HeatZoneSystem
    [SerializeField] SpriteRenderer spriteRenderer;
    private Color originalColor;

    private void Start()
    {

        playerHealth = GetComponent<PlayerHealth>(); //  Detecta automáticamente el script en el jugador
        
        if (playerHealth != null)
        {
            InvokeRepeating("ApplyColdDamage", damageInterval, damageInterval); //Aplica daño progresivo sin tocar `PlayerHealth`
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null) 
        {

            originalColor=spriteRenderer.color;


        
        }
    }
    public void SetSafeZone(bool state)//como necesiatamos trabajar con zonas de calor esta funcion 
        //sirve para trabajar con el HeatZoneSystem para que cuando el jugador este cerca de la zona de calor
        //o "zona segura" este no sufra daño por frio.

    {
        isInHeatZone = state; // Cambia el estado del jugador respecto a la zona de calor



        if (isInHeatZone)
        {
            
            CancelInvoke("ApplyColdDamage");
        }
        else
        {
           InvokeRepeating("ApplyColdDamage", damageInterval, damageInterval);
        }





    }

    private void ApplyColdDamage()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageFloor); // Llama a `TakeDamage()` directamente en `PlayerHealth`
            Debug.Log("El jugador pierde vida por frío. Vida actual: " + playerHealth.currentHealth);
            UpdateSpriteColor();
        }
    }
    private void UpdateSpriteColor() 
    {

        if (spriteRenderer == null || playerHealth == null) return;
        float healthRatio = (float)playerHealth.currentHealth / playerHealth.maxHealth;
        Color coldColor = Color.Lerp(Color.blue, originalColor, healthRatio);
        spriteRenderer.color = coldColor;
    }
}
