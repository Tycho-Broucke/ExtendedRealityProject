using UnityEngine;
using TMPro;

namespace TMPro.Examples
{
    public class TextChanger : MonoBehaviour
    {
        public TMP_Text textComponent;
        public Transform buttonTransform;
        public Transform tableTransform;  // Reference to the table's transform
        public float sphereScale = 1.0f;

        private GameObject sphere;
        private Renderer sphereRenderer;

        private void Start()
        {
            // Create the sphere
            sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.localScale = Vector3.one * sphereScale;

            // Position the sphere initially below the button and make it invisible
            if (buttonTransform != null)
            {
                Vector3 spherePosition = buttonTransform.position - new Vector3(0, 1.0f, 0);  // Start off below the button
                sphere.transform.position = spherePosition;
            }

            // Get the Renderer component and make the sphere invisible initially
            sphereRenderer = sphere.GetComponent<Renderer>();
            sphereRenderer.enabled = false;
        }

        public void ChangeText()
        {
            if (textComponent != null)
            {
                textComponent.text = "What is the formula to calculate the volume of a sphere?";
            }

            // Position the sphere on top of the table
            if (tableTransform != null)
            {
                Vector3 spherePosition = tableTransform.position + new Vector3(0, tableTransform.localScale.y / 2 + sphere.transform.localScale.y / 2, 0);
                sphere.transform.position = spherePosition;
            }

            // Toggle the sphere's visibility
            if (sphereRenderer != null)
            {
                sphereRenderer.enabled = !sphereRenderer.enabled;
            }
        }
    }
}
