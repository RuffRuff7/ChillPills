using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody m_Rigidbody;
    float m_Speed;

    Vector3 direction;

    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        m_Speed = 5.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && m_Rigidbody.velocity.y == 0) 
        {
            Jump();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Conveyor")
        {
            Debug.Log("collided");
            ConveyorPlatform platform = collision.gameObject.GetComponent<ConveyorPlatform>();
            direction = platform.getDirection();
            m_Rigidbody.velocity = direction * m_Speed;
        }
    }

    void Jump()
    {
        Debug.Log("Jumped");
        m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x,m_Rigidbody.velocity.y + m_Speed * 2f, m_Rigidbody.velocity.z);
    }

}
