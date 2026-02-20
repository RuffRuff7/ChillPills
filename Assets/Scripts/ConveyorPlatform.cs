using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorPlatform : MonoBehaviour
{
    Vector3 direction;
    float middlex;
    MeshFilter meshfilter;
    Mesh mesh;
    // Start is called before the first frame update
    
    void Start()
    {
        direction = transform.forward;
        meshfilter = gameObject.GetComponent<MeshFilter>();
        mesh = meshfilter.mesh;
        middlex = (mesh.bounds.size.x * transform.localScale.x)/2.0f;
    }

    public Vector3 getDirection()
    {
        return direction;
    }

    public float getMiddleX()
    {
        return middlex;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(middlex);
    }
}
