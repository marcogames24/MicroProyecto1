using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 3; // M�xima cantidad de corazones
    public int currentHealth; // Salud actual
    public Image[] heartIcons; // Array de im�genes de corazones (directamente en el Canvas)

    void Start()
    {
        // Inicializa la salud
        currentHealth = maxHealth;
        UpdateHealthUI(); // Aseg�rate de inicializar la interfaz de salud
    }

    public void TakeDamage(int damage)
    {
        // Reduce la salud
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
            Debug.Log("Game Over"); // Aqu� puedes implementar la l�gica de perder el juego
        }

        UpdateHealthUI(); // Actualiza los corazones en el Canvas
    }

    void UpdateHealthUI()
    {
        // Oculta los corazones seg�n la salud actual
        for (int i = 0; i < heartIcons.Length; i++)
        {
            if (i < currentHealth)
            {
                heartIcons[i].gameObject.SetActive(true); // Muestra el coraz�n
            }
            else
            {
                heartIcons[i].gameObject.SetActive(false); // Oculta el coraz�n
            }
        }
    }
    //Referencia al codigo HealingItem
    public void Heal(int amount)
    {
        currentHealth += amount;

        // Aseg�rate de que la salud no exceda el m�ximo permitido
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateHealthUI(); // Actualiza la interfaz de salud
        Debug.Log($"Salud del jugador: {currentHealth}");
    }





}







