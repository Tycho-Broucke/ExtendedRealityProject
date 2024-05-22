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
        float yPosition = Mathf.Lerp( 1f, 0, amount);

        transform.position = new Vector3(transform.position.x, startPosition.y + yPosition, transform.position.z);
    }

    public void MoveLeftRight(float amount)
    {
        float xPosition = Mathf.Lerp(0, 0.88f, amount);

        transform.position = new Vector3(transform.position.x + xPosition, transform.position.y, transform.position.z);
    }
}
