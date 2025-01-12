using UnityEngine;

public class StarField : MonoBehaviour
{
    public GameObject starPrefab; // Prefab de estrella
    public int starCount = 100; // Número de estrellas
    public float starSpeed = 50f; // Velocidad de movimiento de las estrellas
    public Vector2 spawnArea = new Vector2(1920, 1080); // Área de aparición (ancho x alto)

    private GameObject[] stars; // Arreglo para las estrellas

    void Start()
    {
        Debug.Log("El script StarField ha comenzado.");

        // Verificar que el prefab está configurado
        if (starPrefab == null)
        {
            Debug.LogError("¡El prefab de estrella no está asignado!");
            return;
        }

        Debug.Log("El prefab de estrella está asignado correctamente.");

        // Inicializar el arreglo de estrellas
        stars = new GameObject[starCount];

        // Crear y posicionar las estrellas
        for (int i = 0; i < starCount; i++)
        {
            Vector2 randomPosition = GetRandomPosition();
            GameObject star = Instantiate(starPrefab, transform);
            star.GetComponent<RectTransform>().anchoredPosition = randomPosition;

            Debug.Log($"Estrella {i} creada en posición: {randomPosition}");
            stars[i] = star;
        }
    }

    void Update()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].GetComponent<RectTransform>().anchoredPosition += 
                Vector2.down * starSpeed * Time.deltaTime;

            if (stars[i].GetComponent<RectTransform>().anchoredPosition.y < -spawnArea.y / 2)
            {
                Vector2 newPosition = GetRandomPosition();
                newPosition.y = spawnArea.y / 2;
                stars[i].GetComponent<RectTransform>().anchoredPosition = newPosition;
            }
        }
    }

    private Vector2 GetRandomPosition()
    {
        float x = Random.Range(-spawnArea.x / 2, spawnArea.x / 2);
        float y = Random.Range(-spawnArea.y / 2, spawnArea.y / 2);
        return new Vector2(x, y);
    }
}
