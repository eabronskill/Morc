using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaidManager : MonoBehaviour
{
    public float countDownTime;
    [HideInInspector] public float countDownTimeRemaining;
    [HideInInspector] public float score;
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
