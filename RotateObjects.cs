using UnityEngine;

public class RotateObjects : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed = 90f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the rotation amount for this frame
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Rotate the object around the Y-axis
        transform.Rotate(0f, rotationAmount, 0f);
    }
}