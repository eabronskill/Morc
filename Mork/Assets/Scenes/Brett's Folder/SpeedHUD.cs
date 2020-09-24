using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class SpeedHUD : MonoBehaviour
{
    public GameObject Player;
    public GameObject whiteBox;
    public GameObject BoostHUD;
    public GameObject SlowHUD;
    public Text boostText;
    public Text slowText;
    private float boost;
    private float slow;

    // Start is called before the first frame update
    void Start()
    {
        boost = 0;
        slow = 0;
    }

    // Update is called once per frame
    void Update()
    {
        boost = Player.GetComponent<Boar>().speedBoostTimeRemaining;
        slow = Player.GetComponent<Boar>().slowTimeRemaining;

        if (boost > 0.0 | slow > 0.0)
        {
            whiteBox.SetActive(true);

            if (boost > 0.0)
            {
                BoostHUD.SetActive(true);
                boostText.text = "Speedboost: " + boost;
                
            }
            if (slow > 0.0)
            {
                SlowHUD.SetActive(true);
                slowText.text = "Slowdown: " + slow;

            }
            if (boost > 0.0 && slow > 0.0)
            {
                whiteBox.SetActive(false);
                BoostHUD.SetActive(false);
                SlowHUD.SetActive(false);
            }
        }
        else
        {
            whiteBox.SetActive(false);
            BoostHUD.SetActive(false);
            SlowHUD.SetActive(false);
        }
    }
}
