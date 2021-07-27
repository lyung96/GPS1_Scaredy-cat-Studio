using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class obtainedkey : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    public float Dialoguespeed;
    private int index = 0;
    private bool firstline = false;
    public GameObject dialog;
    public Animator DialogueAnimator;
    public static bool StartDialogue = true, endDialogue = true;


    // Update is called once per frame
    void Update()
    {
        Debug.Log("sentence index: " + index);
        if (chestopener.obtainedkey && chestopener.playerinchestrange)
        {
            if (StartDialogue)
        {
            endDialogue = false;

            Debug.Log("Start Dialogue");
            DialogueAnimator.SetTrigger("enter");
            StartDialogue = false;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                nextSentence();
                Debug.Log("sentence index: " + index);
            }

        }
        }
    }

    public IEnumerator WriteSentence()
    {
        foreach (char Character in Sentences[index].ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(Dialoguespeed);
        }
        index++;
    }

    public void nextSentence()
    {
        if (index <= Sentences.Length - 1)
        {
            DialogueText.text = string.Empty;
            StartCoroutine(WriteSentence());

        }
        else
        {
            DialogueText.text = string.Empty;
            DialogueAnimator.SetTrigger("exit");
            index = 0;
            endDialogue = true;
            Destroy(dialog);
        }
    }
}
