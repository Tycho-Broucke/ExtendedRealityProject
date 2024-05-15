using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.InputSystem;  // Include this for the new Input System


public class MouseKeyboardSimulator : MonoBehaviour
{
    private Camera mainCamera;
    public EventSystem eventSystem; // Assign this via the Inspector

    void Start()
    {
        mainCamera = Camera.main; // Ensure the main camera is used for this
    }

    void Update()
    {
        // Check for mouse click using the new Input System
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                var button = hit.collider.GetComponent<UnityEngine.UI.Button>();
                if (button != null)
                {
                    button.onClick.Invoke();  // Invoke the button's onClick event
                }
            }
        }
    }
}
