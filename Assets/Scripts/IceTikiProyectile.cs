using UnityEngine;

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

    void Start()
    {
        nextFireTime = Time.time + fireRate; // Este es un temporizador de disparo, que se usa para realizar el primer
                                             // disparo del proyectil
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

            GameObject snowball = Instantiate(IceTikiProyectilePrefab, spawnPoint.position, spawnPoint.rotation);
            snowball.SetActive(true);        
        
            Rigidbody rb = snowball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = spawnPoint.forward * speed; // Como en la escena de juego existen 2 IceTikis 
                                                                // con diferentes orientaciones, el  disparo se
                                                                //realizara en base a la direccion del Spawn
            }

        Destroy(snowball, lifetime); //aqui permitira la destruccion del proyectil luego de que transcurra 
                                     //cierto tiempo , que le definamos al principio

        //GameObject snowball = Instantiate(IceTikiProyectilePrefab, spawnPoint.position, Quaternion.identity);
        //Rigidbody rb = snowball.GetComponent<Rigidbody>();

        //if (rb != null)
        //{
        //    rb.linearVelocity = transform.forward * speed; // Mueve el proyectil en línea recta
        //}

        //Destroy(snowball, lifetime); //aqui permitira la destruccion del proyectil luego de que transcurra 
        //                            //cierto tiempo , que le definamos al principio
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Si el proyectil golpea al jugador
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Aplica la cantidad de daño que le hayamos definido anteriormente
                                                 // al jugador 
            }
            Destroy(gameObject); // Destruye el proyectil luego de que sea impactado por el jugador
        }
    }
}



