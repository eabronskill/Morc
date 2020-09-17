using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text NameText;
    public Text DialogueText;

    private Queue<string> sentences;
    private string game;
    private GameObject DialogueUI;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        DialogueUI = GameObject.Find("DialogueUI");
        DialogueUI.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        game = dialogue.game;
        DialogueUI.SetActive(true);
        NameText.text = dialogue.name;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        NextSentence();
    }
    public void NextSentence()
    {
        if(sentences.Count==0)
        {
            EndDialogue();
            return;
        }
        string sentence = (string)sentences.Dequeue();
        DialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        if(game.Equals("Boar"))
        {
            this.SendMessage("loadingNextScene",3);
        }
    }

}
