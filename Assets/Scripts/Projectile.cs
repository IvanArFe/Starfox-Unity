using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 100.0f;

    private Rigidbody rb;

    private void Start()
    {
        // Asignar la capa de "Projectile"
        gameObject.layer = LayerMask.NameToLayer("Projectile");

        rb = GetComponent<Rigidbody>();
        Impulse();
    }

    private void Impulse()
    {
        rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destruir el proyectil al impactar
        Destroy(gameObject);
    }
}
