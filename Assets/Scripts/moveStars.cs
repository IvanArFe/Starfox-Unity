using UnityEngine;

public class moveStars : MonoBehaviour
{
    public float minSpeed = -10f; // Velocidad mínima
    public float maxSpeed = -30f; // Velocidad máxima
    private float zMovement;

    private void Start()
    {
        zMovement = Random.Range(minSpeed, maxSpeed) * Time.deltaTime;
    }

    private void Update()
    {
        transform.Translate(0, 0, zMovement);
    }

    // Método para destruir la estrella (llámalo al final de la partida)
    public void DestroyStar()
    {
        Destroy(gameObject);
    }
}