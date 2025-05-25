using UnityEngine;

public class NewCharacterDamage : MonoBehaviour
{
    public int attackDamage = 1;
    public float attackRange = 1f;
    public LayerMask enemyLayer;
    public Animator animator;
    public Rigidbody rb; // Referencia al Rigidbody del personaje
    private float lastHorizontalDirection = 1;
    float CharacterOriginalScaleX = 14.467f;

    private void Update()
    {
        // Detectar ataque al presionar O
        if (Input.GetKeyDown(KeyCode.O))
        {
            PerformAttack();
        }
    }

    public void UpdateDirection(float horizontalInput)
    {
        if (horizontalInput > 0)
        {
            lastHorizontalDirection = 1;
        }
        else if (horizontalInput < 0)
        {
            lastHorizontalDirection = -1;
        }

        // Aplicar la dirección al personaje manteniendo su escala original
        transform.localScale = new Vector3(lastHorizontalDirection * CharacterOriginalScaleX, transform.localScale.y, transform.localScale.z);
    }

    void PerformAttack()
    {
        animator.SetBool("IsFighting", true);
        animator.SetFloat("AttackState", 1); // Activa el golpe en el Blend Tree

        DetectAndDamageEnemies();

        Invoke("ResetAttack", 0.2f);
    }

    private void ResetAttack()
    {
        animator.SetFloat("AttackState", 0); // Regresa al estado normal

        // Si el personaje no sigue peleando, vuelve a su estado base
        if (!Input.GetKey(KeyCode.O))
        {
            animator.SetBool("IsFighting", false);
        }
    }


    private void DetectAndDamageEnemies()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
                Debug.Log("Golpeaste a " + enemy.name + " y provocaste " + attackDamage + " de daño.");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
