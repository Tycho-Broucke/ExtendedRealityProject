using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Material cubeMaterial;

    void Start()
    {
        cubeMaterial = GetComponent<Renderer>().material;
        if (cubeMaterial == null)
        {
            Debug.Log("Cube has no material");
        }
    }

    public void ChangeColorRandomly()
    {
        float r = Random.value;
        float g = Random.value;
        float b = Random.value;

        cubeMaterial.color = new Color(r, g, b);
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
