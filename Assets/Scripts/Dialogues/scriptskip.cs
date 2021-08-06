using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptskip : MonoBehaviour
{
    public DialogBegining dialogbegin;

    private void Start()
    {
        dialogbegin = GetComponent<DialogBegining>();
    }
    public void skipbeginningdialogue()
    {
        dialogbegin.stopsentence();
    }
}
