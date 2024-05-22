using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class Cube : MonoBehaviour
{
    private MeshRenderer cubeRenderer;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
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
        float yPosition = Mathf.Lerp(startPosition.y + 1f, startPosition.y, amount);

        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
    }

    public void MoveLeftRight(float amount)
    {
        float xPosition = Mathf.Lerp(startPosition.x, startPosition.x + 0.88f, amount);

        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }
}
