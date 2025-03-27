using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f; // Velocidad de movimiento
    public float jumpForce = 5f; // Fuerza del salto
    public Rigidbody rb; // Referencia al Rigidbody del personaje

    private Vector3 movement;

    void Update()
    {
        // Captura la entrada de las teclas ASWD
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        // Aplica movimiento en los ejes X y Z
        Vector3 move = new Vector3(movement.x, 0, movement.z) * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + move);

        // Detecta cuando se presiona Espacio y aplica el salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}

 



