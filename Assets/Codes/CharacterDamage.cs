using UnityEngine;

public class CharacterDamage : MonoBehaviour
{

    public int attackDamage = 1; // Da�o que el personaje causar� a los enemigos
    public float attackRange = 1f; // Rango del ataque
    public LayerMask enemyLayer; // Capa de los enemigos
    public Animator animator; // Referencia al Animator del personaje
    private bool isFacingRight = true; // Direcci�n inicial del personaje (mirando a la derecha)

    private void Update()
    {
        // Detecta el ataque al presionar O
        if (Input.GetKeyDown(KeyCode.O))
        {
            PerformAttack();
        }
    }

    public void UpdateDirection(float horizontalInput)
    {
        // Actualiza la direcci�n del personaje
        if (horizontalInput > 0)
        {
            isFacingRight = true;
        }
        else if (horizontalInput < 0)
        {
            isFacingRight = false;
        }
    }

    private void PerformAttack()
    {
        // Activar el trigger de ataque seg�n la direcci�n
        if (isFacingRight)
        {
            animator.SetTrigger("AttackRight"); // Activar animaci�n de ataque hacia la derecha
        }
        else
        {
            animator.SetTrigger("AttackLeft"); // Activar animaci�n de ataque hacia la izquierda
        }

        // Detectar y aplicar da�o a los enemigos
        DetectAndDamageEnemies();
    }

    private void DetectAndDamageEnemies()
    {
        // Detectar enemigos usando una esfera en el rango de ataque
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            // Verifica si el enemigo tiene el componente EnemyHealth
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage); // Aplica da�o al enemigo
                Debug.Log("Golpeaste a " + enemy.name + " y provocaste " + attackDamage + " de da�o.");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja el rango de ataque en la escena para referencia
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}




