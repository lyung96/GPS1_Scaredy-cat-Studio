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
    private bool finishedtext;
    public GameObject dialog;
    public Animator DialogueAnimator;
    public static bool StartDialogue = true, firstlineup = false;
    public static  bool endDialogue = true;
    private float texttimer;
    private float textCounter = 0.005f;

    void Update()
    {
        if (chestopener.dialoguestart)
        {
            if (StartDialogue)
            {
                endDialogue = false;
                DialogueAnimator.SetTrigger("enter");
                DialogueText.text = string.Empty;
                StartCoroutine(WriteSentence());
                Debug.Log("start dialogue");
                firstlineup = true;
                chestopener.dialoguestart = false;
                StartDialogue = false;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (finishedtext)
                    {
                        nextSentence();
                    }
                }

            }
        }
       if (Input.GetKeyDown(KeyCode.P))//use when u fk up
       {
           finishedtext = true;
       }
    }


    public IEnumerator WriteSentence()
    {
        foreach (char Character in Sentences[index].ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(Dialoguespeed);
            finishedtext = false;


        }
        yield return new WaitForSeconds(0.2f);
        texttimer += Time.deltaTime;

        if (texttimer >= textCounter)
        {
            texttimer = 0f;
            index++;
            finishedtext = true;
        }


    }

    public void nextSentence()
    {
        if (index <= Sentences.Length - 1)
        {
            DialogueText.text = string.Empty;
            StartCoroutine(WriteSentence());
            //WriteSentence();

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
