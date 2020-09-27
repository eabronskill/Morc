using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text NameText;
    public Text DialogueText;

    private Queue<string> sentences;
    private GameObject DialogueUI;
    private int countSentences = 0;
    private string game;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        DialogueUI = GameObject.Find("DialogueUI");
        DialogueUI.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        countSentences = 0;
        sentences.Clear();
        game = dialogue.game;
        DialogueUI.SetActive(true);
        NameText.text = dialogue.name;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        //If Mork wins the race, change the dialogue
        if(dialogue.loveValue>0)
        {
            sentences.Dequeue();
            sentences.Dequeue();
            sentences.Dequeue();
        }
        NextSentence();
    }
    public void NextSentence()
    {
        if(countSentences==3)
        {
            EndDialogue();
            return;
        }
        string sentence = (string)sentences.Dequeue();
        DialogueText.text = sentence;
        countSentences++;
    }

    public void EndDialogue()
    {
        if (game.Equals("Boar"))
        {
            this.SendMessage("loadingNextScene","ObstacleCourse");
        }
        else
        {
            DialogueUI.SetActive(false);
        }
    }

}
