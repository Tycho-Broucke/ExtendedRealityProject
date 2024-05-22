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

        cubeRenderer.material.SetColor("Color", new Color(r, g, b));
    }

    public void MoveUpDown(float amount)
    {
        float yPosition = Mathf.Lerp(2f, 1.27f, amount);

        transform.position = new Vector3(transform.position.x, startPosition.y + yPosition, transform.position.z);
    }

    public void MoveLeftRight(float amount)
    {
        float xPosition = Mathf.Lerp(0.44f, -0.44f, amount);

        transform.position = new Vector3(transform.position.x, transform.position.y, startPosition.z + xPosition);
    }
}
