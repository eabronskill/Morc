using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRace : LoadingScene
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Boar"))
        {
            loadingNextScene(nextScene);
        }
    }
}
