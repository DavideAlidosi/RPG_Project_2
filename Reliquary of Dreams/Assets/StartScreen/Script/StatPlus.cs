using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StatPlus : MonoBehaviour
{
    private int point = 24;
    public Text pointText;
    public Text numberText;
    private int number = 1;
    public void ClickPlus()
    {
        if (number < 10)
        {   
            number++;
            numberText.text = "" + number;                       
        {
        if (point < 25 && point > 0)
        {
            point--;                   
            pointText.text = "" + point;
        }
    }
  }
}
    
       public void ClickMinus()
    {
        if (number > 1)
        {
            number--;
            numberText.text = "" + number;

          if (point > 0 && point < 24)
            {
                point++;
                pointText.text = "" + point;
            }
        }
    }
} 

