using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bossdefeatmessage : MonoBehaviour
{

    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI NameText;
    public string[] Sentences;
    public float Dialoguespeed;
    public int index = 0;
    public GameObject dialog, goddessicon, mc;
    public Animator DialogueAnimator;
    public static bool StartDialogue = true, endDialogue = true, firstlineup = false, iscutscene = true, quitcutscene = false, skip = false;
    bool mctrue = true, goddesstrue = false;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (Boss.health<=0)
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
                    mctrue = false;
                    goddesstrue = true;
                    if (index == 0)
                    {
                        Debug.Log("Index246");
                        mctrue = false;
                        goddesstrue = true;
                        setgoddessactive();
                        NameText.text = "Yuji";
                        if (index == 8)
                        {
                            NameText.text = "Tengu";
                        }
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //DialogueAnimator.SetTrigger("enter");
                    nextSentence();
                    
                }




            }
        }



    }

    public void setmcactive()
    {
        mc.SetActive(true);
        goddessicon.SetActive(false);
    }

    public void setgoddessactive()
    {
        mc.SetActive(false);
        goddessicon.SetActive(true);
        Debug.Log("goddess 2");
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
        }
        else
        {
            DialogueText.text = string.Empty;
            DialogueAnimator.SetTrigger("exit");
            index = 0;
            endDialogue = true;
            dialog.SetActive(false);
            Obtainedmask3.bossdefeat = true;
            
        }
    }


}
