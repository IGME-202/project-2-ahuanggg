using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum CollisionCheckMethod
{
    AABB,
    Circle
}

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    public List<SpriteRenderer> objects = new List<SpriteRenderer>();



    public CollisionCheckMethod checkMethod;

    public float shipLife;
    public float count;

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            switch(checkMethod)
            {
                case CollisionCheckMethod.AABB:
                    checkMethod = CollisionCheckMethod.Circle;
                    break;
                case CollisionCheckMethod.Circle:
                    checkMethod = CollisionCheckMethod.AABB;
                    break;
            }
        }

        bool isPlayerHit = false;

        for (int i = 2; i < objects.Count; ++i)
        {
            if(CheckForCollision(objects[0], objects[i], checkMethod))
            {
                objects[i].color = Color.red;


                isPlayerHit = true;
                //objects[0].color = Color.red;
            }
            
            else
            {
                objects[i].color = Color.white;

                //objects[0].color = Color.white;
            }
        }

        if (isPlayerHit)
        {
            objects[0].color = Color.red;

            //GameObject ship = GameObject.Find("Ship");
            //Vehicle vehicle = ship.GetComponent<Vehicle>();
            //vehicle.vehiclePosition = Vector3.zero;

            count++; //count is set so high because the ship can be in the asteroid
            if (count == 1)
            {
                shipLife++;

                if (shipLife == 1)
                {
                    Text t = life1.GetComponent<Text>();
                    t.text = " ";
                }

            }

            if (count == 150)
            {
                shipLife++;
                if (shipLife == 2)
                {
                    Text t = life2.GetComponent<Text>();
                    t.text = " ";
                }
            }

            if (count == 300)
            {
                shipLife++;
                if (shipLife == 3)
                {
                    // restartes the game
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }

            

        }
        else
        {
            objects[0].color = Color.white;
        }

    }

    public bool CheckForCollision(SpriteRenderer objectA, SpriteRenderer objectB, CollisionCheckMethod collisionCheck)
    {
        bool isHitting = false;

        switch(collisionCheck)
        {
            case CollisionCheckMethod.AABB:
                if (objectB.bounds.min.x < objectA.bounds.max.x
                    && objectB.bounds.max.x > objectA.bounds.min.x
                    && objectB.bounds.max.y > objectA.bounds.min.y
                    && objectB.bounds.min.y < objectB.bounds.max.y)
                {
                    isHitting = true;
                }
                break;
            case CollisionCheckMethod.Circle:
                if (Vector3.Distance(objectA.bounds.center, objectB.bounds.center) < (objectA.bounds.size.magnitude + objectB.bounds.size.magnitude) / 2f)
                {
                    isHitting = true;
                }
                break;

        }

       

        return isHitting;
    }

}
