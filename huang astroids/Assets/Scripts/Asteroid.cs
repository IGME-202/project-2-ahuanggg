using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    Vector3 asteroidPosition;


    [SerializeField]
    Vector3 direction;

    Vector3 velocity = Vector3.zero;

    [SerializeField]
    float speed = 0.05f;

    Camera cam;
    public float width;
    public float height;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;

        // spawns the asteroid at a random place
        float xposition = Random.Range(-8.5f, 8.5f);
        float yposition = Random.Range(-4.5f, 4.5f);

        asteroidPosition.x = xposition;
        asteroidPosition.y = yposition;

        // sets a momentum for the astroid
        float xposition2 = Random.Range(-1f, 1f);
        float yposition2 = Random.Range(-1f, 1f);

        direction.x = xposition2;
        direction.y = yposition2;

    }

    // Update is called once per frame
    void Update()
    {

        velocity = direction * speed;

        asteroidPosition += velocity;

        transform.position = asteroidPosition;

        //transform.position += -transform.right * speed * Time.deltaTime;

        // to rotate the whole asteroid
        transform.Rotate(Vector3.forward);

        // to make sure the asteroid loops back around
        if (asteroidPosition.x > 9)
        {
            asteroidPosition.x = -9;
        }
        if (asteroidPosition.x < -9)
        {
            asteroidPosition.x = 9;
        }


        if (asteroidPosition.y > 5)
        {
            asteroidPosition.y = -5;
        }
        if (asteroidPosition.y < -5)
        {
            asteroidPosition.y = 5;
        }
    }
}
