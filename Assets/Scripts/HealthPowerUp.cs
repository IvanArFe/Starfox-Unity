using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public float speed = 5f; 
    private Transform player; 

    private void Start()
    {
        // Encuentra al jugador automáticamente
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform; 
        }
        else
        {
            Debug.LogError("No se encontró un objeto con el tag 'Player'. Asegúrate de que el jugador tiene el tag correcto.");
        }
    }

    private void Update()
    {
        // El power-up se mueve hacia el jugador
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Solo actúa si la colisión es con el jugador
        if (other.CompareTag("Player"))
        {
            // Añadir vida al jugador
            Vida playerVida = other.GetComponent<Vida>();
            if (playerVida != null)
            {
                playerVida.AddHealth(25); // Añade 25 de vida
            }

            // Destruir este power-up al recogerlo
            Destroy(gameObject);
        }
    }

}
