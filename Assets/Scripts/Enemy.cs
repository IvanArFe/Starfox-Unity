using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemyRange = 70f;
    [SerializeField] float enemyRotationSpeed = 5f;

    private Transform playerTransform;  
    private Gun currentGun;
    private float fireRate;
    private float fireRateDelta;

    private void Start()
    {
        playerTransform = FindFirstObjectByType<SpaceshipController>().transform;   

        currentGun = GetComponentInChildren<Gun>();
        fireRate = currentGun.GetRateOfFire();
    }

    private void Update()
    {
        if(playerTransform) {
            Vector3 playerGroundPos = new Vector3(playerTransform.position.x, 
                                    playerTransform.position.y, playerTransform.position.z);

            //Check if player is not in range, then do nothing
            if(Vector3.Distance(transform.position, playerGroundPos) > enemyRange)
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
            if(fireRateDelta <= 0)
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
}