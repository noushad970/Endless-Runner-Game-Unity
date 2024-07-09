using UnityEngine;

public class RotateObject1 : MonoBehaviour
{
    public float rotationSpeed = 100f; // Rotation speed in degrees per second

    void Update()
    {
        // Get the current rotation
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // Set X and Z rotation to fixed values and increment Y rotation
        currentRotation.x = 90f;
        currentRotation.y += rotationSpeed * Time.deltaTime;
        currentRotation.z = 0f;

        // Apply the new rotation
        transform.rotation = Quaternion.Euler(currentRotation);
    }
}
