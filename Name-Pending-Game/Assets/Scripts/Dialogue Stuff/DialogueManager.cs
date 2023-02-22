using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Animator animator;
    private int _currentDialogue;
    
    private void Awake()
    {
        _currentDialogue = 0;
    }
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void ShipDialogue(Dialogue dialogue)
    {
        if (_currentDialogue == 7)
        {
            EndDialogue();
            _currentDialogue = 0;
        }
        else
        {
            _currentDialogue++;
        }
        Debug.Log(_currentDialogue);
        if (_currentDialogue == 1)
        {
            animator.SetBool("IsOpen", true);
            nameText.text = dialogue.name;
            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }
        }
        else
        {
            string uga = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(uga));
        }
    }
    public void StartDialouge(Dialogue dialogue, int count)
    {

        if (_currentDialogue == count + 1)
        {
            EndDialogue();
            _currentDialogue = 0;
        }
        else
        {
            _currentDialogue++;
        }
        Debug.Log(_currentDialogue);
        if (_currentDialogue == 1)
        {
            animator.SetBool("IsOpen", true);
            nameText.text = dialogue.name;
            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }
        }
        else
        {
            string uga = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(uga));
        }



    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    
    }
}
