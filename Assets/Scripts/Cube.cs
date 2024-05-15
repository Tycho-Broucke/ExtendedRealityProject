using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private MeshRenderer cubeRenderer;

    void Start()
    {
        if (!TryGetComponent<MeshRenderer>(out cubeRenderer))
        {
            Debug.LogError("Object does not have a MeshRenderer component.");
        }
    }

    public void ChangeColorRandomly()
    {
        float r = Random.value;
        float g = Random.value;
        float b = Random.value;

        cubeRenderer.material.color = new Color(r, g, b);
    }

    public void MoveUpDown(float amount)
    {
        float yPosition = Mathf.Lerp(2f, 1.27f, amount);

        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
    }

    public void MoveLeftRight(float amount)
    {
        float xPosition = Mathf.Lerp(0.44f, -0.44f, amount);

        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }
}
