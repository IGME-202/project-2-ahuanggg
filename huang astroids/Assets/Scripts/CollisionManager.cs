using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollisionCheckMethod
{
    AABB,
    Circle
}

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    List<SpriteRenderer> objects = new List<SpriteRenderer>();

    public CollisionCheckMethod checkMethod;

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

        for (int i = 1; i < objects.Count; ++i)
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
        }
        else
        {
            objects[0].color = Color.white;
        }

    }

    bool CheckForCollision(SpriteRenderer objectA, SpriteRenderer objectB, CollisionCheckMethod collisionCheck)
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
