using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public Image blank;
    public Image speed;
    public Image jump;

    public int powerUp;
    private void Awake()
    {
    }

    private void Update()
    {
        if (powerUp == 1)
            Blank();
        else if (powerUp == 2)
            Speed();
        else
            Jump();
    }

    public void Blank()
    {
        blank.enabled = true;
        speed.enabled = false;
        jump.enabled = false;
    }

    public void Speed()
    {
        blank.enabled = false;
        speed.enabled = true;
        jump.enabled = false;
    }

    public void Jump()
    {
        blank.enabled = false;
        speed.enabled = false;
        jump.enabled = true;
    }
}
