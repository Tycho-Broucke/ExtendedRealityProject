using UnityEngine.InputSystem;
using UnityEngine;

public class RightHandSimulator : MonoBehaviour
{
    public Camera mainCamera;
    public float sensitivity = 100.0f;

    void Update()
    {
        if (Mouse.current != null)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = 0.2f; // Depth adjustment for where the ray should start

            // Convert mouse position from screen coordinates to a world point
            Vector3 worldPoint = mainCamera.ScreenToWorldPoint(mousePos);

            // Optionally adjust the starting point or direction based on your scene setup
            Vector3 rayStart = transform.position; // Start the ray at the transform's position
            Vector3 rayDirection = transform.forward; // Use the transform's forward direction for the ray

            Debug.DrawRay(rayStart, rayDirection * 10, Color.green); // Visualize the ray in the scene view

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                RaycastHit hit;
                if (Physics.Raycast(rayStart, rayDirection, out hit))
                {
                    Debug.Log("Hit: " + hit.collider.name);
                    // Implement additional interaction logic here
                }
            }
        }
    }

}
