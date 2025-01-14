using UnityEngine;

[System.Serializable]
public class SpawnableObject
{
    public GameObject prefab; // Prefab to be generated
    public bool useFixedHeight = false; // Fixed height?
    public float fixedHeight = 0f; // Value in case we use it
    public float spawnInterval = 1f; // Spawn interval for specific models
    public float speed = 10f; // Specific speed fro every model
}

public class ObjectManager : MonoBehaviour
{
    public SpawnableObject[] spawnableObjects; // Prefab of generated object
    public Vector3 spawnRange = new Vector3(10f, 5f, 20f); // Generation range
    public float baseY = 15f;

    private float previousSpawnInt;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Generation cicle independent for every object
        foreach (var spawnable in spawnableObjects)
        {
            StartCoroutine(SpawnRoutine(spawnable));
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private System.Collections.IEnumerator SpawnRoutine(SpawnableObject spawnable)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnable.spawnInterval);

            // Calculate pos Y
            float posY = spawnable.useFixedHeight ? spawnable.fixedHeight : baseY + Random.Range(0, spawnRange.y);

            // Generate random position
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnRange.x, spawnRange.x),
                posY,
                spawnRange.z
            );

            // Create object in generated position
            GameObject newObject = Instantiate(spawnable.prefab, spawnPosition, spawnable.prefab.transform.rotation);

            // Add movement component
            ObjectMovement movement = newObject.AddComponent<ObjectMovement>();
            movement.speed = spawnable.speed;
        }
    }
}
