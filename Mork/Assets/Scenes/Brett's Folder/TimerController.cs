using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    //GameObjects
    public GameObject Timer;
    public GameObject countdownTimer;
    public GameObject Player;
    //Text Components
    public Text timerText;
    public Text countdownText;
    //Floats
    private float countdownTime;
    private float timerTime;
    private int minutes;
    private int seconds;


    // Start is called before the first frame update
    
    void Start()
    {
        Timer.SetActive(true);
        

    }

    // Update is called once per frame
    void Update()
    {
        minutes = (int)Player.GetComponent<RaceManager>().minutesTimeRemaining;
        seconds = (int)Player.GetComponent<RaceManager>().secondsTimeRemaining;
        timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
        
        

        if (Player.GetComponent<RaceManager>().countDownTimeRemaining > 0.0)
        {
            countdownTimer.SetActive(true);
            countdownText.text = Player.GetComponent<RaceManager>().countDownTimeRemaining.ToString();
            
        }
        else
        {
            countdownText.text = "GO!";
            Invoke(nameof(turnOffGo), 2);
            
        }

        if (Player.GetComponent<RaceManager>().won)
        {
            countdownTimer.SetActive(true);
            countdownText.text = "You won!";
        }
        if (Player.GetComponent<RaceManager>().lost)
        {
            countdownTimer.SetActive(true);
            countdownText.text = "You lost!";
        }
    }

    private void turnOffGo()
    {
        countdownTimer.SetActive(false);
    }
}
