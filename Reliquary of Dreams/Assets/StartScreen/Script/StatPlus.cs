using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StatPlus : MonoBehaviour
{
    public Text numberText;
    private int number = 1;
    public int numberMax;
    public void ClickPlus()
    {
        if (number < 10)
        {
            number++;
            numberText.text = "" + number;
        }
    }
    public void ClickMinus()
    {
        if (number > 1)
        {
            number--;
            numberText.text = "" + number;
        }
    }
} 
