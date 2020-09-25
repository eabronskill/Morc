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
    private bool lastActiveWasBoost; 

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

            if (boost > 0.0 && boost > slow)
            {
                lastActiveWasBoost = true;
                BoostHUD.SetActive(true);
                SlowHUD.SetActive(false);
                boostText.text = "Speedboost: " + boost;
                
            }
            else if (slow > 0.0 && slow > boost)
            {
                lastActiveWasBoost = false;
                SlowHUD.SetActive(true);
                BoostHUD.SetActive(false);
                slowText.text = "Slowdown: " + slow;

            }
            else if (boost == slow)
            {
                print("Boost equals Slow");
                print(lastActiveWasBoost);
                
                if (lastActiveWasBoost) //In spite of this variable, the if and else below do not trigger.
                {
                    SlowHUD.SetActive(true);
                    BoostHUD.SetActive(false);
                    slowText.text = "Slowdown: " + slow;
                }
                else
                {
                    BoostHUD.SetActive(true);
                    SlowHUD.SetActive(false);
                    boostText.text = "Speedboost: " + boost;
                }
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
