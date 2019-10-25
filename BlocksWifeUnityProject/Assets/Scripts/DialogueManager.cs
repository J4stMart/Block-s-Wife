using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguebox;

    public Text nameText;
    public Text dialogueText;

    public PlayerController2D controller;
    public Animator animator;

    public float typingspeed = 0.02f;

    private Queue<Sentence> sentences;
    private Dialogue currentDialogue;

    private bool coroutineRunning = false;
    private bool finishSentence = false;

    public GameObject bridge;
    public BoxCollider2D woodpile;

    private bool inConversation = false;

    // Use this for initialization
    void Start()
    {
        sentences = new Queue<Sentence>();
        dialoguebox.SetActive(false);
    }

    private void Update()
    {
        if (inConversation && Input.GetKeyDown(KeyCode.T))
        {
            if (coroutineRunning)
                finishSentence = true;
            else
                DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        controller.physicsActive = false;
        dialoguebox.SetActive(true);

        currentDialogue = dialogue;

        sentences.Clear();

        foreach (Sentence sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        inConversation = true;

        Sentence sentence = sentences.Dequeue();

        if (sentence.left)
        {
            nameText.text = currentDialogue.nameLeft;
            nameText.alignment = TextAnchor.UpperLeft;
        }
        else
        {
            nameText.text = currentDialogue.nameRight;
            nameText.alignment = TextAnchor.UpperRight;
        }

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence.text));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        coroutineRunning = true;

        foreach (char letter in sentence.ToCharArray())
        {
            if (finishSentence)
            {
                dialogueText.text = sentence;
                finishSentence = false;
                break;
            }

            dialogueText.text += letter;
            yield return new WaitForSeconds(typingspeed);
        }

        coroutineRunning = false;
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        StartCoroutine(ActivatePlayer());
        dialoguebox.SetActive(false);

        var player = GetComponent<Player>();

        if(player.makeBridge == true)
        {
            bridge.SetActive(true);
            woodpile.enabled = true;
        }

        player.AddScore(0.1f);

        inConversation = false;
    }

    IEnumerator ActivatePlayer()
    {
        yield return new WaitForSeconds(0.1f);
        controller.physicsActive = true;
    }
}
