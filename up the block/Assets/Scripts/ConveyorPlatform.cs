using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorPlatform : MonoBehaviour
{
    Vector3 direction;
    // Start is called before the first frame update
    
    void Start()
    {
        direction = transform.forward;
    }

    public Vector3 getDirection()
    {
        return direction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
