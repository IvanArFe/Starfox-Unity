using UnityEngine;

public class ProjectilePowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab; // Prefab del powerup
    public Transform player; // Referencia al jugador
    public float spawnInterval = 15f; // Intervalo de aparición
    public float spawnDistance = 20f; // Distancia inicial del powerup desde el jugador

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPowerUp), 0f, spawnInterval);
    }

    private void SpawnPowerUp()
    {
        if (player != null)
        {
            // Generar una posición aleatoria alrededor del jugador
            Vector3 randomOffset = Random.insideUnitSphere * spawnDistance;
            randomOffset.y = Mathf.Abs(randomOffset.y); // Asegurar que el PowerUp esté sobre el jugador

            Vector3 spawnPosition = player.position + randomOffset;

            // Instanciar el powerup
            Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
