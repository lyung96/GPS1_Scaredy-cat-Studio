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
    public GameObject dialog;
    public Animator DialogueAnimator;
    public static bool StartDialogue = true, endDialogue = true, firstlineup=false;
    private float texttimer;
    private float textCounter= 0.005f;
    public Animator cameraanim;
    public static bool iscutscene, quitcutscene = false, skip=false;

    private void Start()
    {
        StartDialogue = true;
        skip = false;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        StartDialogue = true;
    //        if (endDialogue==false)
    //        {
    //            StartDialogue = false;
    //        }
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (StartDialogue)
            {
                endDialogue = false;
                DialogueAnimator.SetTrigger("enter");
                startdialogue();
                StartDialogue = false;

            }
            else
            {
                //Debug.Log("next line");
                DialogueAnimator.SetTrigger("enter");
                if (Input.GetKeyDown(KeyCode.E))
                {
                   
                    //Debug.Log("sentence: " + index);
                    nextSentence();
                    //Debug.Log("sentence index: " + index);
                }
            }

            if (Input.GetKeyDown(KeyCode.P))//use when u fk up
            {
                finishedtext = true;
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
       
        

        //if (texttimer >= textCounter)
        //{
        //    texttimer = 0f;
        //    
        //    finishedtext = true;
        //}
       

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

    public void startdialogue()
    {
        StartCoroutine(WriteSentence());
        firstlineup = true;
        if (firstlineup)
        {
            Invoke("startcutscene", 3.0f);
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
    }
}
