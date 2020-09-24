using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRace : LoadingScene
{
    [HideInInspector] public bool won;
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
        }
    }
}
