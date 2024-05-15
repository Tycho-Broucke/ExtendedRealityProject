using UnityEngine;
using UnityEngine.InputSystem;

public class HeadMotionSimulator : MonoBehaviour
{
    public float sensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float verticalRotation = 0.0f;
    private float horizontalRotation = 0.0f;

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        horizontalRotation = rot.y;
        verticalRotation = rot.x;
        // Lock the cursor for a better simulation experience
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Mouse.current != null)
        {
            float mouseX = Mouse.current.delta.x.ReadValue();
            float mouseY = Mouse.current.delta.y.ReadValue();

            horizontalRotation += mouseX * sensitivity * Time.deltaTime;
            verticalRotation -= mouseY * sensitivity * Time.deltaTime; // Subtract to invert the vertical axis

            verticalRotation = Mathf.Clamp(verticalRotation, -clampAngle, clampAngle);

            Quaternion localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0.0f);
            transform.rotation = localRotation;
        }
    }
}
