using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody m_Rigidbody;
    public float m_Speed;

    bool collided;

    bool jumped;
    public Vector3 direction;

    float yDirection;

    float xPos;

    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        m_Speed = 6.0f;
        yDirection = 0.0f;
        jumped = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (collided)
        {
            
           if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
                Jump();
            }
            m_Rigidbody.velocity = direction * m_Speed;
        }
        if (!collided && !jumped)
        {
            m_Rigidbody.velocity = -transform.up * 8.0f;
        }
        // if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && m_Rigidbody.velocity.y == 0) 
        // {
        //     Jump();
        // }
    }

    void OnCollisionEnter(Collision collision)
    {
        collided = true;
        jumped = false;
        if (collision.gameObject.tag == "Conveyor")
        {
            Debug.Log("collided");
            
            m_Speed = 2.0f;
            ConveyorPlatform platform = collision.gameObject.GetComponent<ConveyorPlatform>();
            direction = platform.getDirection();
            yDirection = 0.0f;
            direction.y = yDirection;
        }
    }

    void Jump()
    {
        Debug.Log("Jumped");
        jumped = true;
        // m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x,m_Rigidbody.velocity.y + m_Speed * 8f, m_Rigidbody.velocity.z);
        yDirection = 4.0f;
        direction.y = yDirection;
        // m_Rigidbody.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        // m_Rigidbody.AddForce(transform.up * 20f);
    }

    void OnCollisionExit(Collision collision)
    {
        collided = false;
        m_Speed = 0.0f;
        // yDirection = 0.0f;
        // direction.y = yDirection;
    }

}
