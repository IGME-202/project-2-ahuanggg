using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{

    Vector3 vehiclePosition = Vector3.zero;

    [SerializeField]
    Vector3 direction = Vector3.right;

    Vector3 velocity = Vector3.zero;

    [SerializeField]
    float speed = 0.00001f;

    [SerializeField]
    float turnSpeed = 0.0001f;

    public float maxSpeed = 1f;
    

    Camera cam;
    public float width;
    public float height;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //accelerate or speed increases
            speed += 0.01f;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            while (speed >= 0.000001f)
            { 
                speed *= .95f;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //turn left
            if (turnSpeed < 5f)
            {
                turnSpeed += 0.2f;
            }
            else
            {
                turnSpeed = 5;
            }
            //direction += Vector3.left;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            while (turnSpeed >= 0.000001f)
            {
                turnSpeed *= .95f;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //turn right
            if (turnSpeed > -5f)
            {
                turnSpeed -= 0.2f;
            }
            else
            {
                turnSpeed = -5;
            }

            //direction += Vector3.right;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            while (turnSpeed <= -0.000001f)
            {
                turnSpeed *= .95f;
            }
        }


        direction = Quaternion.Euler(0, 0, turnSpeed) * direction;

        velocity = direction * speed;

        vehiclePosition += velocity;

        transform.position = vehiclePosition;

        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

        if(vehiclePosition.x > 9)
        {
            vehiclePosition.x = -9;
        }
        if (vehiclePosition.x < -9)
        {
            vehiclePosition.x = 9;
        }


        if (vehiclePosition.y > 5)
        {
            vehiclePosition.y = -5;
        }
        if (vehiclePosition.y < -5)
        {
            vehiclePosition.y = 5;
        }
    }
}
