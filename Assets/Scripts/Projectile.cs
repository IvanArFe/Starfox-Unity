using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 100.0f;   //make sure to test this value
                                                    //I don't know why 500f worked fine on my laptop
                                                    //acccording to the video,
                                                    //but it is too high on my desktop

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Impulse();
    }

    private void Impulse()
    {
        rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
    }

    // para que cuando choque el proyectil se destruya
    private void OnTriggerEnter(Collider other)
    {
        // Destruir el proyectil al impactar
        Destroy(gameObject);
    }

}
