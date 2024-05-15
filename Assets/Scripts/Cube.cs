using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveUpDown(float amount)
    {
        float newPosition = Mathf.Lerp(3f, 0.27f, amount);

        transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
    }

    public void MoveLeftRight(float amount)
    {
        float newPosition = Mathf.Lerp(0.44f, -0.44f, amount);

        transform.position = new Vector3(transform.position.x, transform.position.y, newPosition);
    }
}
