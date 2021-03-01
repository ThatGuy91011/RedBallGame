using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public PlayerController player;

    public Canvas ui;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.isStrong = true;
        ui.GetComponent<PowerUp>().powerUp = 3;
        Destroy(this.gameObject);
    }
}
