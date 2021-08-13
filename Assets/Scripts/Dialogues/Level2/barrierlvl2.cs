using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class barrierlvl2 : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    public float Dialoguespeed;
    private int index = 0;
    private bool finishedtext;
    public GameObject dialog;
    public Animator DialogueAnimator;
    public static bool StartDialogue = true, endDialogue = true, skip = false, startsequence=false;
    private float texttimer;
    private float textCounter = 0.007f;

    private void Start()
    {
        startsequence = false;
    }

    void Update()
    {
        if (level2barrier.startdialogue)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (StartDialogue)
                {
                    endDialogue = false;
                    DialogueAnimator.SetTrigger("enter");
                    StartDialogue = false;
                    nextSentence();
                }
                else
                {
                    if (finishedtext)
                    {
                        nextSentence();
                    }

                }
                //Debug.Log("sentence index: " + index);
            }


            if (Input.GetKeyDown(KeyCode.P))//use when u fk up
            {
                finishedtext = true;
            }

        }
               
    }


    public IEnumerator WriteSentence()
    {
        if (skip == false)
        {
            foreach (char Character in Sentences[index].ToCharArray())
            {
                DialogueText.text += Character;
                yield return new WaitForSeconds(Dialoguespeed);
                Debug.Log("detect char: " + Character);
                finishedtext = false;


            }
            texttimer += Time.deltaTime;
            //Debug.Log("time: " + texttimer);

            if (texttimer >= textCounter)
            {
                texttimer = 0f;
                index++;
                finishedtext = true;
            }
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
            StartDialogue = true;
            endDialogue = true;
        }
    }

    public void stopsentence()
    {

        skip = true;
        Debug.Log("skip");
        if (skip)
        {
            index++;
            if (index > Sentences.Length - 1)
            {
                DialogueText.text = string.Empty;
                DialogueAnimator.SetTrigger("exit");
                index = 0;
                endDialogue = true;
                Destroy(dialog);
                //skip = false;
            }
        }
    }
}
