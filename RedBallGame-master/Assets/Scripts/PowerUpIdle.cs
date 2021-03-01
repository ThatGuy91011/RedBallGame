using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpIdle : MonoBehaviour
{
    private Transform tf;
    private float i = 0;
    private bool j = false;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!j)
        {
            tf.position = tf.position + transform.up * .01f;
            i += .01f;
            if (i > .09f)
                j = true;
        }
        else
        {
            tf.position = tf.position - transform.up * .01f;
            i -= .01f;
            if (i == 0)
                j = false;
        }
    }
}
