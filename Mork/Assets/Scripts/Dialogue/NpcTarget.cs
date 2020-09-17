using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NpcTarget : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            this.SendMessage("TriggerDialogue");
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            this.SendMessage("TriggerDialogue");
            Console.WriteLine("Got into Dialogue");
        }
    }
}
