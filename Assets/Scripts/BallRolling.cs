using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BallRolling : MonoBehaviour
{

    //Reference to the RigidBody component in the ball called rb
    public Rigidbody rb;

    public float xspeed = 0f;
    public float zspeed = 500f;
    public int wall_hit = 0;

    void FixedUpdate()
    {
        rb.AddForce(xspeed * Time.deltaTime, 0, zspeed * Time.deltaTime);
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Wall")
        {
            //If it bounces off 2 walls in a row the next time it bounces off a wall it'll change angle
            wall_hit++;
            if (wall_hit > 2)
            {
                xspeed = Random.Range(0f, 500f);
                zspeed = -1 * zspeed;
            }
            else
            {
                xspeed = -1 * xspeed;
                zspeed = -1 * zspeed;
                wall_hit = 0;
            }
        }

        if (collision.gameObject.tag == "Sphere")
        {
            xspeed = -1 * Random.Range(0f, 500f);
            zspeed = -1 * zspeed;
        }
    }
}
