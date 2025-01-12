using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField]
    public GameObject cam;
    [SerializeField]
    public float moveSpeed = 10f;    // Movement speed
    [SerializeField]
    public float rotationSpeed = 20f;  // Rotation speed
    [SerializeField]
    public float maxRotationAngleX = 10f; // Maximum rotation angle for X (new)
    [SerializeField]
    public float maxRotationAngleY = 20f; // Maximum rotation angle for Y-axis tilt
    [SerializeField]
    public float maxRotationAngleZ = 45f; // Maximum rotation angle

    // Movement range constraints
    [SerializeField]
    public Vector2 horizontalRange = new Vector2(-40f, 40f); // Min and max for horizontal movement
    [SerializeField]
    public Vector2 verticalRange = new Vector2(-8f, 20f);     // Min and max for vertical movement

    // Camera follow settings
    [SerializeField]
    public Vector2 horizontalCamRange = new Vector2(-25f, 25f); // Min and max for horizontal movement
    [SerializeField]
    public Vector2 verticalCamRange = new Vector2(-5f, 5f);     // Min and max for vertical movement
    [SerializeField]
    public Vector3 cameraOffset = new Vector3(0f, 0f, -25f); // Offset relative to the spaceship
    [SerializeField]
    public float cameraFollowSpeed = 5f; // Speed of camera follow movement

    [SerializeField]
    public bool isRolling = false; 

    void Update()
    {
        // Movement
        float horizontalInput = Input.GetAxis("Horizontal"); // Left and right
        float verticalInput = Input.GetAxis("Vertical");   // Up and down

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);

        // Apply movement
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // Clamp position to the defined range
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, horizontalRange.x, horizontalRange.y);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, verticalRange.x, verticalRange.y);
        transform.position = clampedPosition;

        if (!isRolling) {
            // Rotation
            float targetRotationX = verticalInput * maxRotationAngleX;
            float targetRotationY = horizontalInput * maxRotationAngleY;
            float targetRotationZ = horizontalInput * maxRotationAngleZ;
            Quaternion targetRotation = Quaternion.Euler(-15 + targetRotationX, 180 + targetRotationY, targetRotationZ);

            // Smoothly rotate the spaceship
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
        
        // Camera follow
        Vector3 desiredCameraPosition = transform.position + cameraOffset;
        desiredCameraPosition.y = Mathf.Min(verticalCamRange.y, Mathf.Max(verticalCamRange.x, desiredCameraPosition.y));
        desiredCameraPosition.y += 12f;
        desiredCameraPosition.x = Mathf.Min(horizontalCamRange.y, Mathf.Max(horizontalCamRange.x, desiredCameraPosition.x));
        cam.transform.position = Vector3.Lerp(cam.transform.position, desiredCameraPosition, Time.deltaTime * cameraFollowSpeed);
    }
}