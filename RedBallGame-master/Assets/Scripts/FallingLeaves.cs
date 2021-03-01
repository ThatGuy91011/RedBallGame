using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLeaves : MonoBehaviour
{
    private Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        Random.seed = (int)System.DateTime.Now.Ticks;
    }

    // Update is called once per frame
    void Update()
    {
        tf.position = tf.position - transform.up * Random.Range(0.01f, 0.07f);
        if (tf.position.y <= -10)
        {
            tf.position = new Vector3(tf.position.x, 3, 0);
        }
    }
}
