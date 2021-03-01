using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Sprite[] healths;
    public Image healthCanvas;
    public bool damaged = false;
    public bool healed = false;
    public int i = 1;
    // Start is called before the first frame update
    void Start()
    {
        healthCanvas = GetComponent<Image>();
        healthCanvas.sprite = healths[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            damaged = false;
            HealthDown();
        }

        if (healed)
        {
            healed = false;
            HealthUp();
        }

        if (i == 4)
        {
            Application.Quit();
        }
    }

    public void HealthDown()
    {
        healthCanvas.sprite = healths[i];
        i++;
    }

    public void HealthUp()
    {
        --i;
        healthCanvas.sprite = healths[i];
    }
}
