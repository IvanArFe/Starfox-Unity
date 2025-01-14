using UnityEngine;

public class moveStars : MonoBehaviour
{
    public float minSpeed = -10f; // Velocidad m�nima
    public float maxSpeed = -30f; // Velocidad m�xima
    private float zMovement;

    private void Start()
    {
        zMovement = Random.Range(minSpeed, maxSpeed) * Time.deltaTime;
    }

    private void Update()
    {
        transform.Translate(0, 0, zMovement);
    }

    // M�todo para destruir la estrella (ll�malo al final de la partida)
    public void DestroyStar()
    {
        Destroy(gameObject);
    }
}