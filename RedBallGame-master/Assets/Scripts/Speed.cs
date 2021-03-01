using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
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
        player.isSpeedy = true;
        ui.GetComponent<PowerUp>().powerUp = 2;
        Destroy(this.gameObject);
    }
}
