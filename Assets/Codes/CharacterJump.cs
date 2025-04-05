using UnityEngine;

public class CharacterJump : MonoBehaviour
{

    public float jumpForce = 5f; // Fuerza del salto
    private Rigidbody rb; // Referencia al Rigidbody del jugador

    void Start()
    {
        // Obtener el componente Rigidbody del jugador
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("El jugador no tiene un componente Rigidbody asignado.");
        }
    }

    void Update()
    {
        // Detectar si se presiona la tecla P
        if (Input.GetKeyDown(KeyCode.P))
        {
            Jump(); // Llamar a la función de salto
        }
    }

    void Jump()
    {
        if (rb != null)
        {
            // Aplicar una fuerza hacia arriba
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("El jugador ha saltado.");
        }
    }
}


