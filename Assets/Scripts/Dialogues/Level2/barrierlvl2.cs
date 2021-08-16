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
       if (startsequence==false)
       {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (level2barrier.startdialogue)
                {
                    if (StartDialogue)
                    {
                        if (skip == false)
                        {
                            endDialogue = false;
                            DialogueText.text = string.Empty;
                            DialogueAnimator.SetTrigger("enter");
                            StartCoroutine(WriteSentence());
                            StartDialogue = false;
                        }
                    }
                    else
                    {
                        nextSentence();
                    }

                    //Debug.Log("sentence index: " + index);
                }


            }
        }
        


    }


    private bool iswriting = false;
    public char[] currentsentence;
    public IEnumerator WriteSentence()
    {
        if (iswriting)
        {
            //Debug.Log("iswriting");
            yield return null;

        }
        else
        {
            int counter = 0;
            if (skip == false)
            {
                DialogueText.text = string.Empty;
                iswriting = true;
                currentsentence = Sentences[index].ToCharArray();
                foreach (char Character in currentsentence)
                {
                    counter++;
                    DialogueText.text += Character;
                    yield return new WaitForSeconds(Dialoguespeed);
                    //finishedtext = false;
                }
                index++;
                yield return new WaitUntil(() => currentsentence.Length == counter);
                iswriting = false;
            }

        }

    }


    public void nextSentence()
    {
        if (index <= Sentences.Length - 1)
        {
       
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
            startsequence = true;
        }
    }

  
}
