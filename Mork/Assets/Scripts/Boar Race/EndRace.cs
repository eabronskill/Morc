using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRace : LoadingScene
{

    new void Start()
    {
        base.Start();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boar"))
        {
            this.SendMessage("loadingNextScene", "MainArea");
        }
    }
}
