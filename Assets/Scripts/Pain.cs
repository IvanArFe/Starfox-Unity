using UnityEngine;
using System.Collections;

public class Pain : MonoBehaviour
{

    [SerializeField]
    float painAmount = 25.0f;

    private void OnTriggerEnter(Collider other)
    {
        Vida targetVida = other.gameObject.GetComponent<Vida>();
        if (targetVida != null)
        {
            targetVida.DoDamage(painAmount);

            // Si el objeto es un enemigo y su vida llega a 0
            if (other.CompareTag("Enemy") && targetVida.currentHealth <= 0)
            {
                Enemy enemy = other.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.OnDeath();
                }
            }
        }
    }


}
