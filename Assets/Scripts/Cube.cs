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

        cubeRenderer.material.color = new Color(50, 50, 50);
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
        transform.position += 2 * amount * Vector3.up;
    }

    public void MoveLeftRight(float amount)
    {
        float xPosition = Mathf.Lerp(0.44f, -0.44f, amount);

        transform.position = new Vector3(transform.position.x, transform.position.y, xPosition - 2.7f);
    }

    public void RotateAroundX(float amount)
    {
        float xPosition = Mathf.Lerp(0.44f, -0.44f, amount);

        transform.position = new Vector3(transform.position.x, transform.position.y, xPosition - 2.7f);
    }
}
