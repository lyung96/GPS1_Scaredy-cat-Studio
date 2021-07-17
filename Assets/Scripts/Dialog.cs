using System.Collections;
using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    public float Dialoguespeed;
    private int index=0;
    private bool firstline=false;
    public GameObject dialog;
    public Animator DialogueAnimator;
    public static bool StartDialogue = false, endDialogue = true;


    // Update is called once per frame
    void Update()
    {
            if(StartDialogue) 
            {
                if(Input.GetKeyDown(KeyCode.V))
                {
                    endDialogue = false;
                    DialogueAnimator.SetTrigger("enter");
                    firstline = true;
                }
            }  
            if (firstline)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    nextSentence();
                }
            }
    }

    public IEnumerator WriteSentence()
    {
        foreach(char Character in Sentences[index].ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(Dialoguespeed);
            index++;
        }
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
            StartDialogue = true;
            endDialogue = true;
        }
    }
}
