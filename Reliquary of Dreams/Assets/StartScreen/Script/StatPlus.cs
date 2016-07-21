using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StatPlus : MonoBehaviour
{
    private int point = 24;
    public Text pointText;
    public Text numberText;
    private int number = 1;
    ChangeScene refChange;
    public void ClickPlus()
    {
        refChange = FindObjectOfType<ChangeScene>();

        if (refChange.point < 25 && refChange.point > 0)
        {
            
            if (number < 10)
            {
                number++;
                numberText.text = "" + number;
                refChange.point--;
                pointText.text = "" + refChange.point;
            }
        }   
    
    }

    
    public void ClickMinus()
    {
        refChange = FindObjectOfType<ChangeScene>();
        

          if (refChange.point >= 0 && refChange.point < 24 && number != 1)
            {
                refChange.point++;
                pointText.text = "" + refChange.point;
            if (number > 1)
            {
                number--;
                numberText.text = "" + number;
            }
        }
    }
} 

