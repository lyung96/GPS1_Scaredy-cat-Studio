using System.Collections;
using TMPro;
using UnityEngine;

public class DialogBegining : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    public float Dialoguespeed;
    private int index=0;
    private bool finishedtext;
    public GameObject dialog;
    public Animator DialogueAnimator;
    public static bool StartDialogue=true , endDialogue= true;
    private float texttimer;
    private float textCounter= 0.007f;


    // Update is called once per frame
    void Update()
    {
        //if (MovePopUpInstructions.entertutorialarea)
        //{
            if (StartDialogue)
            {
                endDialogue = false;

                Debug.Log("Start Dialogue");
                DialogueAnimator.SetTrigger("enter");
                StartDialogue = false;
                nextSentence();
                
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(finishedtext)
                    {
                        nextSentence();
                    }
                    Debug.Log("sentence index: " + index);
                }
               
            }
        if (Input.GetKeyDown(KeyCode.P))//use when u fk up
        {
            finishedtext = true;
        }
        //}
    }

    public IEnumerator WriteSentence()
    {
        foreach(char Character in Sentences[index].ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(Dialoguespeed);
            Debug.Log("detect char: "+ Character);
            finishedtext = false;
            
            
        }
        texttimer += Time.deltaTime;
        Debug.Log("time: " + texttimer);

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
