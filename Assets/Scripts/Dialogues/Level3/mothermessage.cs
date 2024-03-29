using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mothermessage : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI NameText;
    public string[] Sentences;
    public float Dialoguespeed;
    public int index = 0;
    public GameObject dialog, goddessicon, mc, upgrade;
    public Animator DialogueAnimator;
    public static bool StartDialogue = true, endDialogue = true, firstlineup = false, iscutscene = true, quitcutscene = false, skip = false;
    bool mctrue = true, goddesstrue = false;
    bool TenguDied
    {
        get
        {
            return Boss.health <= 0;
        }
    }
    UpgradeMenu upgradepanel;

    private void Start()
    {

    }
    private void Update()
    {
        Debug.Log("tengu dieedddd " + TenguDied);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (mothertrigger.inrange)
            {
                if (TenguDied)
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
                        //DialogueAnimator.SetTrigger("enter");
                        nextSentence();
                    }

                    if (index % 2 == 0)
                    {
                        Debug.Log("Index246");
                        mctrue = true;
                        goddesstrue = false;
                        setmcactive();
                        NameText.text = "Yuji";
                        if (index == 8)
                        {
                            NameText.text = "Shinji";
                        }
                    }
                    else
                    {
                        Debug.Log("Index135");
                        mctrue = false;
                        goddesstrue = true;
                        setgoddessactive();
                        NameText.text = "Women";
                        if (index == 5 || index == 7)
                        {
                            NameText.text = "Mom";
                        }
                    }
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
            Invoke("setupgrade", 1f);
            Boss.health = 50;
        }
    }

    void setupgrade()
    {
        upgradepanel = FindObjectOfType<UpgradeMenu>().GetComponent<UpgradeMenu>();
        upgradepanel.Setupgradepaneltrue();
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
            //skip = false;
        }

    }

}
