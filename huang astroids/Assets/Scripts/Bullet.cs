using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    Vector3 vehiclePosition;

    [SerializeField]
    Vector3 direction = Vector3.right;

    Vector3 velocity = Vector3.zero;

    [SerializeField]
    float speed = 0.075f;

    GameObject shot;

    bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || hasStarted)
        {
            
            shot = Instantiate(bullet, GameObject.Find("Ship").transform.position, Quaternion.identity) as GameObject;
            
            direction = GameObject.Find("Ship").transform.rotation * direction;
            
            shot.transform.Translate(direction * speed * Time.deltaTime);

            hasStarted = true;

            

            Destroy(shot, 3f);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            hasStarted = false;
        }
        


    }

}
