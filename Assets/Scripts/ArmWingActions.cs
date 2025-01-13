using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArmWingActions : MonoBehaviour
{
    public Image BarraBooster;

    [SerializeField]
    GameObject projectilePrefab;

    [SerializeField]
    GameObject bombPrefab;

    [SerializeField]
    Transform projectileSpawnPoint;

    [SerializeField]
    Transform enemyPosition;

    [SerializeField]
    float boostSpeed = 5f; // Speed of the smooth boost transition

    [SerializeField]
    float boostRestoreAmmount = 0.01f; // Ammount to restore boost at every frame

    [SerializeField]
    float projectileSpeed = 100f;

    [SerializeField]
    float bombSpeed = 25f;

    [SerializeField]
    int shootingCooldown = 100; // Cooldown to shoot again
    [SerializeField] float powerUpDuration = 6f; // Duración del powerup
    [SerializeField] float powerUpFireRate = 0.33f; // Disparos por segundo durante el powerup

    private bool isPowerUpActive = false;

    bool isBoosting = false;
    bool isBoostingTransition = false;
    float boostAmmount = 100f;
    bool restoringBoost = true;
    float targetZPosition;
    int cooldownCtr = 0;    // Counter that increments each frame. Works as a shooting cooldown

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the target position to the current position
        targetZPosition = transform.position.z;
        enemyPosition = FindFirstObjectByType<Enemy>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (restoringBoost) // Restore the boost slowly
            boostAmmount = Mathf.Min(100, boostAmmount + boostRestoreAmmount);
        else
        {  // If boost is not supposed to be restoring, then the Armwing is boosting
            boostAmmount = Mathf.Max(0, boostAmmount - boostRestoreAmmount * 3);  // Spend the boost 3 times quicker than it is restored
            if (boostAmmount <= 0)
            {    // If player runs out of boost
                targetZPosition -= 5; // Move back
                restoringBoost = true;   // Enable boost restoring
                isBoosting = false; // Stop boosting
                isBoostingTransition = true; // Start the boost transition
            }
        }
        BarraBooster.fillAmount = boostAmmount / 100f; //per a que sorti la barra del HUD
        cooldownCtr++;

        // Trigger shooting
        if (Input.GetButtonDown("Fire1"))
        {
            if (cooldownCtr > shootingCooldown)
            {   // Don't shoot unless the counter for the shooting action is past a certain threshold
                GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
                // Make the projectile move forward in the direction of the spawn point's forward vector
                Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
                if (projectileRigidbody != null)
                {
                    Vector3 forwardDirection = -projectileSpawnPoint.forward;
                    forwardDirection.y = 0; // Ignore x rotation
                    forwardDirection.Normalize(); // Ensure it's still a unit vector
                    projectileRigidbody.linearVelocity = forwardDirection * projectileSpeed;
                }
                cooldownCtr = 0;    // Reset counter
            }
        }
        // Trigger boost
        if (Input.GetButtonDown("Fire2"))
        {
            if (isBoosting) // If player was boosting
                targetZPosition -= 5; // Move back
            else    // If player wasn't boosting
                targetZPosition += 5; // Move forward

            restoringBoost = !restoringBoost;
            isBoosting = !isBoosting;
            isBoostingTransition = true; // Start the boost transition
        }
        // Trigger Bomb
        if (Input.GetKeyDown("b"))
        {
            if (enemyPosition)
            {
                GameObject bomb = Instantiate(bombPrefab, projectileSpawnPoint.position, Quaternion.identity);
                SmartBomb bombScript = bomb.AddComponent<SmartBomb>();
                bombScript.Initialize(enemyPosition, bombSpeed);
            }
        }

        // Smoothly move towards the target Z position
        if (isBoostingTransition)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.z = Mathf.Lerp(currentPosition.z, targetZPosition, Time.deltaTime * boostSpeed);

            // Check if the movement is close enough to the target to stop
            if (Mathf.Abs(currentPosition.z - targetZPosition) < 0.01f)
            {
                currentPosition.z = targetZPosition;
                isBoostingTransition = false;
            }

            transform.position = currentPosition;
        }
    }

    public void ActivateProjectilePowerUp()
    {
        if (!isPowerUpActive)
        {
            StartCoroutine(PowerUpRoutine());
        }
    }


    private IEnumerator PowerUpRoutine()
    {
        isPowerUpActive = true;
        float elapsedTime = 0f;

        while (elapsedTime < powerUpDuration)
        {
            FireProjectile(); // Dispara automáticamente
            elapsedTime += powerUpFireRate;
            yield return new WaitForSeconds(powerUpFireRate);
        }

        isPowerUpActive = false;
    }



    private void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = -projectileSpawnPoint.forward * projectileSpeed; // Usar el eje Z negativo
        }
    }
}