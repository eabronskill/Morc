using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public float raceTime, countDownTime;
    [HideInInspector] public float secondsTimeRemaining, countDownTimeRemaining, minutesTimeRemaining;
    [HideInInspector] public bool won, lost;
    private Boar boar;
    private EndRace endRace;
    public float waitTime = 2f;
    private bool countDownHasBegun, raceHasBegun;
    private bool runOnce;
    // Start is called before the first frame update
    void Start()
    {
        boar = GameObject.FindGameObjectWithTag("Boar").GetComponent<Boar>();
        if (!boar) Debug.Log("BOAR IS NULL");
        endRace = GameObject.FindGameObjectWithTag("SceneTrigger").GetComponent<EndRace>();
        if (!endRace) Debug.Log("END TRIGGER IS NULL");

        countDownTimeRemaining = countDownTime;
        secondsTimeRemaining = Mathf.FloorToInt(raceTime % 60);
        minutesTimeRemaining = Mathf.FloorToInt(raceTime / 60);
    }

    // Update is called once per frame
    void Update()
    {
        if (lost) 
        {
            StartCoroutine(endRace.loadingNextScene("MainArea"));
            return;
        }
        if (endRace.won) { won = true; return; }

        if (raceHasBegun)
        {
            if (raceTime > 0)
            {
                raceTime -= Time.deltaTime;
                secondsTimeRemaining = Mathf.FloorToInt(raceTime % 60);
                minutesTimeRemaining = Mathf.FloorToInt(raceTime / 60);
            }
            else
            {
                secondsTimeRemaining = 0;
                minutesTimeRemaining = 0;
                lost = true;
                boar.Lost();
            }
            return;
        }

        if (!countDownHasBegun && !runOnce) 
        { 
            Invoke(nameof(StartCountdown), waitTime); 
            runOnce = true;  
            return; 
        }
        else if (countDownHasBegun)
        {
            if (countDownTime > 0)
            {
                countDownTime -= Time.deltaTime;
                countDownTimeRemaining = Mathf.FloorToInt(countDownTime % 60);
            }
            else
            {
                raceHasBegun = true;
                countDownTimeRemaining = 0;
                boar.BeginRace();
            }
        }
    }

    private void StartCountdown()
    {
        countDownHasBegun = true;
    }
}
