using UnityEngine;
using System.Collections.Generic;
public class IceTikiProyectile : MonoBehaviour
{
   
    public GameObject IceTikiProyectilePrefab; // Prefab del proyectil de Ice Tikki

    public Transform spawnPoint; //Este hace referencia al punto de origen de donde se encuentra el proyectil
                                 //en la escena
    
    public int damage = 1; // Esta variable se encarga de definir el daño que provoca el proyectil al personaje
    
    public float speed = 5f; // Esta es la velocidad del proyectil 
    
    public float lifetime = 5f; // Esta varibale define el tiempo que transcurre el proyectil
                                // antes que este se destruya
    
    public float fireRate = 3f; // Como el enemigo Tikki de hielo tiene una animación de ataque este 
                                // variable se utiliza para sincronizar el tiempo en que el enemigo
                                // realiza sus disparos en la escena, ademas, evita que los disparos
                                // sean infinitos

    private float nextFireTime; //esta variable se utiliza para controlar el proximo disparo que realiza el proyectil
    private Queue<GameObject> projectilePool = new Queue<GameObject>();
    void Start()
    {
        nextFireTime = Time.time + fireRate; // Este es un temporizador de disparo, que se usa para realizar el primer
                                             // disparo del
        for (int i = 0; i < 10; i++) // Ajusta este número según las necesidades
        {
            GameObject projectile = Instantiate(IceTikiProyectilePrefab);
            projectile.SetActive(false);
            projectilePool.Enqueue(projectile);
        }
        Debug.Log("Pool de proyectiles inicializado con " + projectilePool.Count + " proyectiles.");

    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot(); // Dispara un nuevo proyectil
            nextFireTime = Time.time + fireRate; // Reinicia el temporizador de disparo para que siga disparando,
                                                 // dependiendo del tiempo que le definimos con anterioridad
        }
    }

    void Shoot()
    {
        GameObject snowball = GetProjectileFromPool(); //  Usar proyectil reciclado en vez de instanciar uno nuevo

        if (snowball != null)
        {
            snowball.transform.position = spawnPoint.position; // Mantener la dirección según `spawnPoint`
            snowball.transform.rotation = spawnPoint.rotation;
            snowball.SetActive(true);

            Rigidbody rb = snowball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = spawnPoint.forward * speed; //  Mantiene la dirección según el enemigo

                Debug.Log(" Proyectil disparado con velocidad " + rb.linearVelocity);
            }
            else
            {
                Debug.LogError(" El proyectil no tiene Rigidbody. Asegúrate de que el prefab tiene uno.");
            }

            StartCoroutine(DeactivateProjectile(snowball, lifetime)); //  Desactivar después de un tiempo
        }
        else
        {
            Debug.LogError(" No se encontró un proyectil disponible en la pool.");
        }
    }

    private GameObject GetProjectileFromPool()
    {
        if (projectilePool.Count > 0)
        {
            GameObject projectile = projectilePool.Dequeue(); //  Recuperar un proyectil de la cola
            return projectile;
        }

        // Si no hay proyectiles disponibles, se crea uno nuevo y se agrega a la cola
        GameObject newProjectile = Instantiate(IceTikiProyectilePrefab);
        newProjectile.SetActive(false);
        projectilePool.Enqueue(newProjectile);
        return newProjectile;
    }


    private System.Collections.IEnumerator DeactivateProjectile(GameObject projectile, float delay)
    {
        yield return new WaitForSeconds(delay);
        projectile.SetActive(false); //  Se desactiva en vez de destruirse
        projectilePool.Enqueue(projectile); //  Se vuelve a agregar al pool

        Debug.Log(" Proyectil reciclado y listo para ser reutilizado.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            gameObject.SetActive(false); //  Se desactiva en vez de destruirse
            projectilePool.Enqueue(gameObject); // Se recicla para futuros disparos

            Debug.Log(" Proyectil impactó al jugador y fue reciclado.");
        }
    }

}



