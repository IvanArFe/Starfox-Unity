using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemyRange = 150f;
    [SerializeField] float enemyRotationSpeed = 5f;
    [SerializeField] GameObject deathEffect; // añadimos el efecto de desintegracion al morir
    private Renderer enemyRenderer;
    private float fadeDuration = 2f; // Duración del fade-out efecto

    private Transform playerTransform;
    private Gun currentGun;
    private float fireRate;
    private float fireRateDelta;

    private void Start()
    {
        playerTransform = FindFirstObjectByType<SpaceshipController>().transform;
        currentGun = GetComponentInChildren<Gun>();
        fireRate = currentGun.GetRateOfFire();

        // Inicializar el renderer del enemigo
        enemyRenderer = GetComponent<Renderer>();
        if (enemyRenderer == null)
        {
            Debug.LogError("No se encontró un Renderer en el enemigo. Asegúrate de que el enemigo tiene un Renderer asignado.");
        }
    }


    private void Update()
    {
        if (playerTransform)
        {
            Vector3 playerGroundPos = new Vector3(playerTransform.position.x,
                                    playerTransform.position.y, playerTransform.position.z);

            //Check if player is not in range, then do nothing
            if (Vector3.Distance(transform.position, playerGroundPos) > enemyRange)
            {
                return; //do nothing because player is not in range
            }

            //PLAYER IN RANGE

            //Rotate Enemy towards player
            Vector3 playerDirection = playerGroundPos - transform.position;
            float enemyRotationStep = enemyRotationSpeed * Time.deltaTime;
            Vector3 newLookDirection = Vector3.RotateTowards(transform.forward, playerDirection,
                                    enemyRotationStep, 0f);
            transform.rotation = Quaternion.LookRotation(newLookDirection);

            fireRateDelta -= Time.deltaTime;
            if (fireRateDelta <= 0)
            {
                currentGun.Fire();
                fireRateDelta = fireRate;
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, enemyRange); //Show a gizmo when selected
    }

    // funcionalidad para desintegrarse
    public void OnDeath()
    {
        // PRIMERO DESINTEGRA
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        // Despues desaparece poco a poco
        StartCoroutine(FadeOutAndDestroy());
    }

    private IEnumerator FadeOutAndDestroy()
    {
        // Obtener el material del renderer
        Material material = enemyRenderer.material;
        Color color = material.color;

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            color.a = alpha;
            material.color = color; // Actualizar la transparencia
            yield return null;
        }

        // Destruir el enemigo después del fade-out
        Destroy(gameObject);
    }
}