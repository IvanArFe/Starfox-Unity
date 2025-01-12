using UnityEngine;

public class HealthPowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab; // Prefab del power-up de vida
    public Transform player;         // Referencia a la nave (jugador)
    public float spawnDistance = 10f; // Distancia detrás del jugador
    public float spawnInterval = 10f; // Tiempo en segundos entre apariciones

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPowerUp), 0f, spawnInterval);
    }

    public void SpawnPowerUp()
    {
        // Si el jugador no está asignado, no hacemos nada
        if (player == null) return;

        // Calcula la posición detrás del jugador
        Vector3 spawnPosition = player.position - player.forward * spawnDistance; // Detrás del jugador
        spawnPosition.y = player.position.y + 2f; // Ajusta ligeramente hacia arriba, si es necesario

        // Instancia el power-up
        Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
    }
}