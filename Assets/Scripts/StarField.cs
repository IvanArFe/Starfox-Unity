using UnityEngine;

public class StarField : MonoBehaviour
{
    public GameObject starPrefab; // Prefab de la estrella
    public int starCount = 100;   // Número de estrellas
    public float starSpeed = 2f; // Velocidad de movimiento de las estrellas
    public Vector2 spawnArea = new Vector2(1920, 1080); // Área de generación (en píxeles)

    void Start()
    {
        for (int i = 0; i < starCount; i++)
        {
            SpawnStar();
        }
    }

    void SpawnStar()
    {
        Vector3 position = new Vector3(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            Random.Range(-spawnArea.y / 2, spawnArea.y / 2),
            0
        );

        GameObject star = Instantiate(starPrefab, position, Quaternion.identity, transform);
        star.transform.localScale = Vector3.one * Random.Range(0.5f, 1.5f);
    }

    void Update()
    {
        foreach (Transform star in transform)
        {
            star.transform.Translate(Vector3.down * starSpeed * Time.deltaTime);

            // Si la estrella sale del área, reubícala arriba
            if (star.position.y < -spawnArea.y / 2)
            {
                star.position = new Vector3(
                    Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                    spawnArea.y / 2,
                    0
                );
            }
        }
    }
}
