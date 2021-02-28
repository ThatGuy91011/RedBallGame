using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            ball.GetComponent<PlayerController>().onGround = true;
        }
    }

    //Check if the object has left the ground
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            ball.GetComponent<PlayerController>().onGround = false;
        }
    }
}
