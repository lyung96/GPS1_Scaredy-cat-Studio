using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialoguetesting : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    public float Dialoguespeed;
    private int index = 0;
    //private bool finishedtext;
    public GameObject dialog;
    public Animator DialogueAnimator;
    public static bool StartDialogue = true, endDialogue = true, firstlineup = false, starttyping=false;
    public Animator cameraanim;
    public static bool iscutscene, quitcutscene = false;

    private void Start()
    {
        quitcutscene = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (StartDialogue)
        {
            endDialogue = false;

            Debug.Log("Start Dialogue");
            DialogueAnimator.SetTrigger("enter");
            StartDialogue = false;
            startdialogue();
        }
        else
        {
            DialogueAnimator.SetTrigger("enter");
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (starttyping!=true)
                {
                    Debug.Log("sentence: " + index);
                    nextSentence();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.P))//use when u fk up
        {
            //finishedtext = true;
        }
        //}
    }

    public IEnumerator WriteSentence()
    {
        foreach (char Character in Sentences[index].ToCharArray())
        {
            if (starttyping==false)
            {
                DialogueText.text += Character;
                yield return new WaitForSeconds(Dialoguespeed);
                starttyping = true;
            }
            Invoke("starttypingfalse", Dialoguespeed*Character);
           
        }
        index++;
    }

    void starttypingfalse()
    {
        starttyping = false;
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

    public void startdialogue()
    {
        DialogueText.text = string.Empty;
        StartCoroutine(WriteSentence());
        firstlineup = true;
        if (firstlineup)
        {
            if (starttyping==false)
            {

                Invoke("startcutscene", 0.0f);
            }

        }

        //WriteSentence();
    }


    void stopcutscene()
    {
        iscutscene = false;
        cameraanim.SetBool("Cutscene1", false);
    }

    void startcutscene()
    {
        DialogueText.text = string.Empty;
        DialogueAnimator.SetTrigger("exit");
        iscutscene = true;
        cameraanim.SetBool("Cutscene1", true);
        Invoke("stopcutscene", 1.5f);
    }
}
