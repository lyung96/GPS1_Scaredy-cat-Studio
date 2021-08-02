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
    public static bool StartDialogue = true, endDialogue = true, firstlineup=false;
    private float texttimer;
    private float textCounter= 0.005f;
    public Animator cameraanim;
    public static bool iscutscene, quitcutscene = false;

    private void Start()
    {
        StartDialogue = true;
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
                //DialogueText.text = string.Empty;
                DialogueAnimator.SetTrigger("enter");
                startdialogue();
                StartDialogue = false;

            }
            else
            {
                Debug.Log("next line");
                DialogueAnimator.SetTrigger("enter");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (finishedtext)
                    {
                        Debug.Log("sentence: " + index);
                        nextSentence();
                    }
                    Debug.Log("sentence index: " + index);
                }
            }

            if (Input.GetKeyDown(KeyCode.P))//use when u fk up
            {
                finishedtext = true;
            }
    }

    public IEnumerator WriteSentence()
    {
        foreach(char Character in Sentences[index].ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(Dialoguespeed);
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
            //if (Input.GetKeyDown(KeyCode.E))
            //{

            Invoke("startcutscene", 3.0f);
            //}
            
        }
       
        //WriteSentence();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartDialogue = false;
            quitcutscene = true;
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
