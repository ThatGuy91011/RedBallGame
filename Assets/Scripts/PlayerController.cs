using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = .1f; //A variable to hold the Speed component
    public float jumpSpeed = .5f;
    public bool onGround = false;
    private Transform tf; // A variable to hold the Transform component
    bool isLeft = false;
    private SpriteRenderer spriteRenderer;
    Rigidbody2D m_Rigidbody; //Defines the sprite as a RigidBody that you can manipulate in the code

    void Start()
    {
        // Get the Transform Component
        tf = GetComponent<Transform>();
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //If the up arrow is pressed...
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (onGround)
            {
                Vector3 jumpMovement = new Vector3(0.0f, 1.0f, 0.0f);
                m_Rigidbody.velocity = jumpMovement * jumpSpeed;
            }

        }


        //If the down arrow is pressed...
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //...move the sprite backwards constantly at the speed you define
            tf.position = tf.position - transform.up * Speed;
        }

        //If the left arrow is pressed...
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isLeft = true;
            tf.position = tf.position - transform.right * Speed;
        }

        //If the right arrow is pressed...
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isLeft = false;
            tf.position = tf.position + transform.right * Speed;
        }

        if (isLeft)
        {
            spriteRenderer.flipX = true;
        }
        else
            spriteRenderer.flipX = false;
    }
}
