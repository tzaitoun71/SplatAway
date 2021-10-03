using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private float speed = 0f;            // The speed that the player will move at.
    public float speedH = 5.0f;
    private float yaw = 0.0f;
    
    

    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Animator anim;                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.


    void Awake()
    {

        // Set up references.
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal") * speed;
        float v = Input.GetAxisRaw("Vertical") * speed;

        // Move the player around the scene.
        Move(h, v);

        
        
    }

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        //movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        //movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        //playerRigidbody.MovePosition(transform.position + movement);

        yaw += speedH * Input.GetAxis("Mouse X");
        //pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(0, yaw, 0.0f);
        transform.Translate(h,0f,v);
        //transform.Rotate(0, y, 0);
        if (Input.GetKey(KeyCode.LeftShift))
        {

        
            if(Input.GetKey("w"))
            {
            //anim.SetBool("Iswalking", true);
            anim.SetBool("IsRunning", true);
            speed = 0.12f;
            }
            else
            {
            speed = 0f;
            //anim.SetBool("Iswalking", false);
            anim.SetBool("IsRunning", false);
            }


        }
        else
        {

            if (Input.GetKey("w"))
            {
                anim.SetBool("Iswalking", true);
                anim.SetBool("IsRunning", false);
                speed = 0.05f;
            }
            else
            {
                speed = 0f;
                anim.SetBool("Iswalking", false);
                anim.SetBool("IsRunning", false);
            }

        }



        if (Input.GetKey("space"))
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }

    }





    

}
