using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public List<string> sentences;

    int index = 0;
    bool isTyping = false;
    
    public UnityEvent UnityEvent;

    public GameObject Ui;
    Coroutine typingCoroutine;

    public GameObject Player;

    void Start()
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        index = 0;
        ShowNextSentence();
    }

    public void ShowNextSentence()
    {
        if (index >= sentences.Count)
        {
            Player.SetActive(true);
            Ui.SetActive(false);
            UnityEvent.Invoke();
            return;
        }

        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(TypeSentence(sentences[index]));
        index++;
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        textUI.text = "";

        foreach (char c in sentence)
        {
            textUI.text += c;
            yield return new WaitForSeconds(0.02f);
        }

        isTyping = false;
    }
    public void Skip()
    {
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            textUI.text = sentences[index - 1];
            isTyping = false;
        }
        else
        {
            ShowNextSentence();
        }
    }
}
