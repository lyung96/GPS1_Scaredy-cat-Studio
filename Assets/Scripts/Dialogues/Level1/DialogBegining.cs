using System.Collections;
using TMPro;
using UnityEngine;

public class DialogBegining : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    public float Dialoguespeed;
    public int index=0;
    private bool finishedtext;
    public GameObject dialog, objectivepopup, skipbutton;
    public Animator DialogueAnimator;
    public static bool StartDialogue = true, endDialogue = true, firstlineup = true;
    private float texttimer;
    private float textCounter= 0.005f;
    public Animator cameraanim;
    public static bool iscutscene, quitcutscene = false, skip=false, popup=false;
    public float cutscenetime;
    public static float dialogcounter;

    private void Start()
    {
        dialogcounter = 0;
        StartDialogue = true;
        skip = false;
        firstlineup = true;
        popup = false;
    }



    // Update is called once per frame
    void Update()
    {
        if (dialogcounter>0)
        {
            skipbutton.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            objectivepopup.SetActive(false);
        }
        if(level1start.enterdialogue)
        {
            if (StartDialogue)
            {
                if (skip == false)
                {
                    endDialogue = false;
                    DialogueAnimator.SetTrigger("enter");
                    startdialogue();
                    //Debug.Log("Index: " + index);
                    
                }
            }
            else
            {
                if (firstlineup)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Invoke("startcutscene", cutscenetime);
                    }
                }
                else if (firstlineup==false)
                {
                    DialogueAnimator.SetTrigger("enter");
                    //nextSentence();
                    //Debug.Log("Index: " + index);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        //Debug.Log("sentence: " + index);
                        nextSentence();
                        //Debug.Log("Index: " + index);
                        //Debug.Log("sentence index: " + index);
                    }
                }
                
            }

            if (Input.GetKeyDown(KeyCode.P))//use when u fk up
            {
                finishedtext = true;
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
            if (skip==false)
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
            if (popup==false)
            {
                popup = true;
                objectivepopup.SetActive(true);
            }
           
        }
    }

    public void stopsentence()
    {
        if (iscutscene==false)
        {
            skip = true;
            Debug.Log("skip");
            if (skip)
            {
                DialogueText.text = string.Empty;
                DialogueAnimator.SetTrigger("exit");
                index = 0;
                endDialogue = true;
                dialog.SetActive(false);
            }
        }
        
    }

    public void startdialogue()
    {
        StartCoroutine(WriteSentence());
        if (index>0)
        {
            StartDialogue = false;
        }
     

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
        firstlineup = false;
    }
}
