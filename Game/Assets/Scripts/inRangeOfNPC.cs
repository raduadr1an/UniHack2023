using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inRangeOfNPC : MonoBehaviour
{
    public float minDistance = 2;
    public GameObject popup;
    public dialogue dialogue1;

    public GameObject player { get; private set; }
    public GameObject blocker;

    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueBox;
    public Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
        if (!player) player = getPlayer();
    }

    private void Update()
    {
        checkDistance();
    }

    private void checkDistance()
    {
        if (Vector2.Distance(this.transform.position, player.transform.position) < minDistance)
        {
            popup.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F) == true)
            {
                StartDialogue(dialogue1);
            }
        }
        else
        {
            popup.SetActive(false);
        }
    }

    public void StartDialogue(dialogue dialogue)
    {
        dialogueBox.SetActive(true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
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

        string sentece = sentences.Dequeue();
        dialogueText.text = sentece;
    }

    private void EndDialogue()
    {
        dialogueBox.SetActive(false);
        popup.SetActive(false);
        Destroy(blocker);
    }

    public GameObject getPlayer()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");
        return player;
    }
}