using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab of generated object
    public float spawnInt = 0.5f; // Time between creations
    public Vector3 spawnRange = new Vector3(10f, 5f, 20f); // Generation range
    public float speed = 10f; // Object speed
    public float baseY = 15f;

    private float previousSpawnInt;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Generation cicle
        previousSpawnInt = spawnInt;
        StartGeneration();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGeneration()
    {
        // Start the generation cycle
        InvokeRepeating(nameof(SpawnObject), 0f, spawnInt);
    }

    void RestartGeneration()

    void SpawnObject()
    {   
        // Generate random position
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnRange.x, spawnRange.x),
            baseY + Random.Range(0, spawnRange.y),
            spawnRange.z
        );

        // Create object in generated position
        GameObject newObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

        // Add movement component
        ObjectMovement movement = newObject.AddComponent<ObjectMovement>();
        movement.speed = speed;
    }
}
