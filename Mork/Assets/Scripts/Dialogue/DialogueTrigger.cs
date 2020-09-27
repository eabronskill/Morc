using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        if(!dialogue.inChat)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            dialogue.inChat = true;
        }
        
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt(this.name,dialogue.loveValue);
    }
    private void OnEnable()
    {
        dialogue.loveValue = PlayerPrefs.GetInt(this.name);
    }
}
