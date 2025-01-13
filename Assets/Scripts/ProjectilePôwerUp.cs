using UnityEngine;

public class ProjectilePowerUp : MonoBehaviour
{
    public float speed = 5f; // Velocidad con la que el PowerUp persigue al jugador
    private Transform player;

    private void Start()
    {
        // Buscar al jugador automáticamente al inicio
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("No se encontró un objeto con la etiqueta 'Player'.");
        }
    }

    private void Update()
    {
        // Si el jugador existe, moverse hacia él
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisiona tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            // Obtener el componente ArmWingActions del jugador
            var armWingActions = other.GetComponent<ArmWingActions>();
            if (armWingActions != null)
            {
                // Activar el PowerUp y destruir el objeto
                armWingActions.ActivateProjectilePowerUp();
                Destroy(gameObject); // Elimina el PowerUp tras recogerlo
            }
        }
    }
}
