using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_BosLifeBar : MonoBehaviour
{
    public Image bosLifeBar;
    private Scr_Bos bosController;
    private float maxLife;

    // Start is called before the first frame update
    void Start()
    {
        bosController = GameObject.Find("Bos").GetComponent<Scr_Bos>();
        maxLife = bosController.life;
    }

    // Update is called once per frame
    void Update()
    {
        bosLifeBar.fillAmount = bosController.life / maxLife;
    }
}
