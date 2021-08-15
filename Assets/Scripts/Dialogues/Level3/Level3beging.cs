using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level3beging : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI NameText;
    public string[] Sentences;
    public float Dialoguespeed;
    public int index = 0;
    public GameObject dialog, goddess, mc;
    public Animator DialogueAnimator;
    public static bool StartDialogue = true, endDialogue = true, firstlineup = false, iscutscene = true, quitcutscene = false, skip = false, startsequence = false;
    public Animator cameraanim;
    bool mctrue = true, goddesstrue = false;

    private void Start()
    {
        chestopener1.obtainedkey = true;
        startsequence = false;
        StartDialogue = true;
        skip = false;
        iscutscene = true;
        mctrue = true;
        goddesstrue = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (startsequence == false)
        {
            if (level1start.enterdialogue && skip == false)
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
                        }
                    }
                    else
                    {
                        DialogueAnimator.SetTrigger("enter");
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            nextSentence();
                        }
                    }






                //if (Input.GetKeyDown(KeyCode.E))
                //{
                //    if (index % 2 == 0)
                //    {
                //        Debug.Log("Index246");
                //        mctrue = true;
                //        goddesstrue = false;
                //        setmcactive();
                //        NameText.text = "Yuji";
                //    }
                //    else
                //    {
                //        Debug.Log("Index135");
                //        mctrue = false;
                //        goddesstrue = true;
                //        setgoddessactive();
                //        NameText.text = "Mysterious Voice";
                //    }

                //}

            }
        }

    }

    public void setmcactive()
    {
        mc.SetActive(true);
        goddess.SetActive(false);
    }

    public void setgoddessactive()
    {
        mc.SetActive(false);
        goddess.SetActive(true);
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
                //Debug.Log(counter);
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
            Destroy(dialog);
            startsequence = true;
        }
    }

    public void stopsentence()
    {
        skip = true;
        Debug.Log("skip");
        if (skip)
        {
            DialogueText.text = string.Empty;
            DialogueAnimator.SetTrigger("exit");
            index = 0;
            endDialogue = true;
            Destroy(dialog);
            Destroy(goddess);
            //skip = false;

        }
    }

    public void startdialogue()
    {

        firstlineup = true;
        if (firstlineup)
        {
            Invoke("startcutscene", 0.0f);

        }
    }

    void stopcutscene()
    {
        iscutscene = false;
        cameraanim.SetBool("Cutscene1", false);
    }

    void startcutscene()
    {
        if (iscutscene == true)
        {
            cameraanim.SetBool("Cutscene1", true);
            Invoke("stopcutscene", 1.0f);
        }

    }
}
