using UnityEngine;
using UnityEngine.UI;

public class FinalBlowBar : MonoBehaviour
{
    public Slider maskSlider;
    public Gradient maskGradient;
    public Image maskFill;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBar(float maskgauge)
    {
        maskSlider.value = maskgauge;

        maskFill.color = maskGradient.Evaluate(maskSlider.normalizedValue);
    }
}
