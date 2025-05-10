using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class SpearAttack : MonoBehaviour
{

    public GameObject spearPrefab; // Prefab de la lanza
    public Transform spearSpawnPoint; // Punto de origen del disparo (debe ser hijo del Character)
    public float spearSpeed = 10f;
    public int spearDamage = 1;
    public LayerMask enemyLayer; // Capa de los enemigos
    private bool facingRight = true;

    private List<GameObject> spearPool = new List<GameObject>();

    void Update()
    {
        // Actualiza la dirección del jugador
        if (Input.GetAxis("Horizontal") > 0)
        {
            facingRight = true;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            facingRight = false;
        }

        // Disparo al presionar "I"
        if (Input.GetKeyDown(KeyCode.I))
        {
            FireSpear();
        }
    }

    void FireSpear()
    {
        GameObject spear = GetSpearFromPool();
        if (spear == null)
        {
            spear = Instantiate(spearPrefab);
            spearPool.Add(spear);
        }

        spear.transform.position = spearSpawnPoint.position;
        spear.transform.rotation = spearSpawnPoint.rotation;
        spear.transform.localScale = facingRight ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);

        spear.SetActive(true);

        // Asignar la capa de los enemigos para que la lanza pueda detectar impactos correctamente
        SpearProyectile spearProyectile = spear.GetComponent<SpearProyectile>();
        if (spearProyectile != null)
        {
            spearProyectile.enemyLayer = enemyLayer;
        }

        Rigidbody rb = spear.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false; // Evita que la lanza caiga
            rb.linearVelocity = facingRight ? new Vector3(spearSpeed, 0, 0) : new Vector3(-spearSpeed, 0, 0);
        }

        StartCoroutine(DeactivateSpear(spear, 5f));
    }

    GameObject GetSpearFromPool()
    {
        foreach (GameObject spear in spearPool)
        {
            if (!spear.activeInHierarchy)
            {
                return spear;
            }
        }
        return null;
    }

    private IEnumerator DeactivateSpear(GameObject spear, float delay)
    {
        yield return new WaitForSeconds(delay);
        spear.SetActive(false);
    }
}


