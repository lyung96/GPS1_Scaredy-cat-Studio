using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider mpSlider;
    public Gradient mpGradient;
    public Image mpFill;
    public GameObject player;
    public void SetMaxMana(int mana)
    {
        mpSlider.maxValue = mana;
        mpSlider.value = mana;

        mpFill.color = mpGradient.Evaluate(1f);
    }

    public void SetMana(int mana)
    {
        mpSlider.value = mana;

        mpFill.color = mpGradient.Evaluate(mpSlider.normalizedValue);
    }
}
