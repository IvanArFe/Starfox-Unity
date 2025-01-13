using UnityEngine;

public class SmartBomb : MonoBehaviour
{
    private Transform target;
    private float speed;

    public void Initialize(Transform targetTransform, float bombSpeed)
    {
        target = targetTransform;
        speed = bombSpeed;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); // Destroy projectile if the target no longer exists
            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Optionally rotate the projectile to face the target
        transform.LookAt(target);

        if (transform.position == target.transform.position) { target = null; }
    }
}

