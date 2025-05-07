using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
  
    public int coinCount = 0; // Contador de monedas
    public int maxCoins = 3; // L�mite de monedas
    public AudioSource audioSource; // Componente para reproducir el sonido
    public AudioClip coinSound; // Sonido de la moneda
    public UnityEngine.UI.Text coinText; // Elemento UI para mostrar las monedas

    private void Start()
    {
        // Inicializa la interfaz con el n�mero de monedas
        coinText.text = "Coins: " + coinCount;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")) // Comprueba si el objeto es una moneda
        {
            if (coinCount < maxCoins) // Si no ha alcanzado el l�mite
            {
                coinCount++; // Aumenta el contador de monedas
                audioSource.PlayOneShot(coinSound); // Reproduce el sonido
                Destroy(other.gameObject); // Elimina la moneda de la escena

                // Actualiza el texto en pantalla
                coinText.text = "Coins: " + coinCount;

                // **Conectar al sistema de tienda usando el m�todo recomendado**
                ShopSystem shopSystem = FindFirstObjectByType<ShopSystem>();
                if (shopSystem != null)
                {
                    shopSystem.AddCoins(1); // Sincronizar las monedas recolectadas
                    Debug.Log($"Sincronizado con la tienda. Monedas actuales: {shopSystem.playerCoins}");
                }
            }
            else
            {
                Debug.Log("L�mite de monedas alcanzado.");
            }
        }
    }


}




