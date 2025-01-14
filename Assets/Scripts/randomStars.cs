using UnityEngine;
using System.Collections;

public class randomStars : MonoBehaviour
{
    public GameObject stars; // Prefab de las estrellas
    public float spawnInterval = 0.1f; // Intervalo de generaci�n
    public float xRange = 200f; // Rango de generaci�n en el eje X
    public float yMin = -10f; // L�mite inferior en el eje Y
    public float yMax = 10f; // L�mite superior en el eje Y
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

    // M�todo para detener la generaci�n (ll�malo al final de la partida)
    public void StopSpawning()
    {
        spawning = false;
    }
}