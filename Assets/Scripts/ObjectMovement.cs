using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 2.5f;

    // Update is called once per frame
    void Update()
    {
        // Movement towards camera
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);

        // When the object reaches an specific coord, delete it
        if(transform.position.z < -18f)
        {
            Destroy(gameObject);
        }
    }
}
