using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_LifeBar : MonoBehaviour
{
    public Image fillLifeBar;
    private Scr_PlayerMovement playerController;
    private float maxLife;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<Scr_PlayerMovement>();
        maxLife = playerController.life;
    }

    // Update is called once per frame
    void Update()
    {
        fillLifeBar.fillAmount = playerController.life/maxLife;
    }
}
