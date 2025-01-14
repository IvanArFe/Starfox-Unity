using UnityEngine;
using System.Collections;

public class randomStars : MonoBehaviour
{
    public GameObject stars; // Prefab de las estrellas
    public float spawnInterval = 0.1f; // Intervalo de generación
    public float xRange = 200f; // Rango de generación en el eje X
    public float yMin = -10f; // Límite inferior en el eje Y
    public float yMax = 10f; // Límite superior en el eje Y
    private bool spawning = true;

    private void Start()
    {
        StartCoroutine(SpawnStars());
    }

    private IEnumerator SpawnStars()
    {
        while (spawning)
        {
            Vector3 randomVector = new Vector3(
                Random.Range(-xRange, xRange),
                Random.Range(yMin, yMax),
                35
            );
            Instantiate(stars, randomVector, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Método para detener la generación (llámalo al final de la partida)
    public void StopSpawning()
    {
        spawning = false;
    }
}