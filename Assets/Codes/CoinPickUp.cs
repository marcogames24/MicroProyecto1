using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
  
    public int coinCount = 0; // Contador de monedas
    public int maxCoins = 3; // Límite de monedas
    public AudioSource audioSource; // Componente para reproducir el sonido
    public AudioClip coinSound; // Sonido de la moneda
    public UnityEngine.UI.Text coinText; // Elemento UI para mostrar las monedas

    private void Start()
    {
        // Inicializa la interfaz con el número de monedas
        coinText.text = "Coins: " + coinCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")) // Comprueba si el objeto es una moneda
        {
            if (coinCount < maxCoins) // Si no ha alcanzado el límite
            {
                coinCount++; // Aumenta el contador de monedas
                audioSource.PlayOneShot(coinSound); // Reproduce el sonido
                Destroy(other.gameObject); // Elimina la moneda de la escena

                // Actualiza el texto en pantalla
                coinText.text = "Coins: " + coinCount;
            }
            else
            {
                Debug.Log("Límite de monedas alcanzado.");
            }
        }
    }
}




