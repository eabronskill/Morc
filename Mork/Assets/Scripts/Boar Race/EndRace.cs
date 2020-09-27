using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRace : LoadingScene
{
    [HideInInspector] public bool won;
    [HideInInspector] public int loveNPC1;
    new void Start()
    {
        base.Start();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boar"))
        {
            won = true;
            this.SendMessage("loadingNextScene", "MainArea");
            loveNPC1++;
        }
    }
    private void OnEnable()
    {
        loveNPC1 = PlayerPrefs.GetInt("FemaleNPC");
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt("FemaleNPC",loveNPC1);
    }
}
