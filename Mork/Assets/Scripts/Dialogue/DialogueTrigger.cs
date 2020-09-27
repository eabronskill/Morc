using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool resetLove = false;

    public void Awake()
    {
        dialogue.loveValue = 0;
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnApplicationQuit()
    {
        resetLove = true;
    }
    private void OnDisable()
    {
        if(!resetLove)
        {
            PlayerPrefs.SetInt(this.name, dialogue.loveValue);
        }
        else
        {
            PlayerPrefs.SetInt(this.name, 0);
        }
    }
    private void OnEnable()
    {
        dialogue.loveValue = PlayerPrefs.GetInt(this.name);
    }
}
