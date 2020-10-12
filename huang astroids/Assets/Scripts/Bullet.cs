using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    Vector3 bulletPosition;

    [SerializeField]
    Vector3 direction = Vector3.zero;

    Vector3 velocity = Vector3.zero;

    [SerializeField]
    float speed = 0.075f;



    public GameObject man = GameObject.Find("Manager");
    public CollisionManager manager = man.GetComponent<CollisionManager>();


    // Start is called before the first frame update
    void Start()
    {
        GameObject ship = GameObject.Find("Ship");
        Vehicle vehicle = ship.GetComponent<Vehicle>();
        direction = vehicle.direction;
        bulletPosition = vehicle.vehiclePosition;

        

        

    }

    // Update is called once per frame
    void Update()
    {

        ////checking for bullet collision with the meteor
        //for (int i = 2; i < manager.objects.Count; ++i)
        //{
        //    if (manager.CheckForCollision(, manager.objects[i], manager.checkMethod))
        //    {
        //        manager.objects[i].color = Color.red;


                
        //        //objects[0].color = Color.red;
        //    }

        //    else
        //    {
        //        manager.objects[i].color = Color.white;

        //        //objects[0].color = Color.white;
        //    }
        //}








        velocity = direction * speed;

        bulletPosition += velocity;

        transform.position = bulletPosition;

        //transform.position += -transform.right * speed * Time.deltaTime;
 

        // to make sure the asteroid loops back around
        if (bulletPosition.x > 9)
        {
            bulletPosition.x = -9;
        }
        if (bulletPosition.x < -9)
        {
            bulletPosition.x = 9;
        }


        if (bulletPosition.y > 5)
        {
            bulletPosition.y = -5;
        }
        if (bulletPosition.y < -5)
        {
            bulletPosition.y = 5;
        }


    }

}
