using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{

    public Vector3 vehiclePosition;

    [SerializeField]
    public Vector3 direction;

    public Vector3 velocity = Vector3.zero;

    [SerializeField]
    float speed = 0.00001f;

    [SerializeField]
    float turnSpeed = 0.0001f;

    [SerializeField]
    GameObject bullet;

    public float shotLimit;

    Camera cam;
    public float width;
    public float height;


    public List<SpriteRenderer> shots = new List<SpriteRenderer>();

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        vehiclePosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shotLimit++;

            if (shotLimit == 1)
            {
                GameObject shot = Instantiate(bullet, vehiclePosition, Quaternion.identity);
                
                
                Destroy(shot, 0.5f);
                Debug.Log(direction);
                shotLimit = 0;
            }
        }

       



        // arrow key code for the spaceship
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //accelerate or speed increases
            if (speed < 0.15f)
            {
                speed += 0.005f;
            }
            else
            {
                speed = 0.15f;
            }
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


       

        


        // if the user is holding space then make bullets but if not holding space push in nulls into the list so the bullets will despawn?



        //code for the ship moving forward and stuff?
        direction = Quaternion.Euler(0, 0, turnSpeed) * direction;

        velocity = direction * speed;

        vehiclePosition += velocity;

        transform.position = vehiclePosition;

        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

      

        // code for the camera and the vehicle moving out of the screen
        if (vehiclePosition.x > 9)
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
