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

    public Animator animator;
    float horizontalMove = 0f;
    float verticalMove = 0f;

    public bool isSpeedy = false;
    public bool isStrong = false;

    public Canvas ui;
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
        horizontalMove = Input.GetAxis("Horizontal") * Speed;
        verticalMove = Input.GetAxis("Vertical") * Speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (onGround)
            animator.SetBool("IsJumping", false);

        if (isSpeedy)
        {
            isSpeedy = false;
            StartCoroutine(SpeedTime());
        }

        if (isStrong)
        {
            isStrong = false;
            StartCoroutine(StrongTime());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ui.GetComponentInChildren<HealthBar>().damaged = true;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            ui.GetComponentInChildren<HealthBar>().healed = true;
        }

        //If the up arrow is pressed...
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("IsJumping", true);
            if (onGround)
            {
                Vector3 jumpMovement = new Vector3(0.0f, 1.0f, 0.0f);
                m_Rigidbody.velocity = jumpMovement * jumpSpeed;
            }

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Nothing
        }


        //If the left arrow is pressed...
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isLeft = true;
            if (tf.position.x <= -342)
            {
                //Do Nothing
            }
            else
                tf.position = tf.position - transform.right * Speed;
        }

        //If the right arrow is pressed...
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isLeft = false;
            if (tf.position.x >= -302)
            {
                //Do Nothing
            }
            else
                tf.position = tf.position + transform.right * Speed;
        }

        if (isLeft)
        {
            spriteRenderer.flipX = true;
        }
        else
            spriteRenderer.flipX = false;
    }


    IEnumerator SpeedTime()
    {
        Speed *= 2;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        Speed /= 2;
        ui.GetComponent<PowerUp>().powerUp = 1;
    }

    IEnumerator StrongTime()
    {
        jumpSpeed *= 2;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        jumpSpeed /= 2;
        ui.GetComponent<PowerUp>().powerUp = 1;
    }
}
