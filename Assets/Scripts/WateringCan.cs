using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
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
        float newPosition = Mathf.Lerp(0f, 1f, amount);

        transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
    }
}
