using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StatPlus : MonoBehaviour
{
    public Text pointText;
    public Text numberText;
    private int number = 1;
    public GameObject alert;
    ChangeScene refChange;
    Singleton stat;
    

    public void ClickPlus()
    {
        refChange = FindObjectOfType<ChangeScene>();
        stat = FindObjectOfType<Singleton>();

        if (refChange.changeStat)
        {


            if (refChange.point < 25 && refChange.point > 0)
            {

                if (number < 10)
                {
                    number++;
                    numberText.text = "" + number;
                    refChange.point--;
                    pointText.text = "Pt: " + refChange.point;
                }
                if (numberText.name == "PuntiAgilità")
                {
                    if (number > stat.perc)
                    {
                        alert.SetActive(true);
                        refChange.changeStat = false;
                        number--;
                        numberText.text = "" + number;
                        refChange.point++;
                        pointText.text = "Pt: " + refChange.point;
                    }
                }

            }

            if (numberText.name == "PuntiForza")
            {
                stat.forza = number;
            }
            if (numberText.name == "PuntiAgilità")
            {
                stat.agilita = number;
            }
            if (numberText.name == "PuntiCostituzione")
            {
                stat.cost = number;
            }
            if (numberText.name == "PuntiIntelligenza")
            {
                stat.intel = number;
            }
            if (numberText.name == "PuntiPercezione")
            {
                stat.perc = number;
            }
            if (numberText.name == "PuntiFortuna")
            {
                stat.fortuna = number;
            }
        }
    }


    public void ClickMinus()
    {
        refChange = FindObjectOfType<ChangeScene>();
        stat = FindObjectOfType<Singleton>();
        if (refChange.changeStat)
        {

            if (refChange.point >= 0 && refChange.point < 24 && number != 1)
            {
                refChange.point++;
                pointText.text = "Pt: " + refChange.point;
                if (number > 1)
                {
                    number--;
                    numberText.text = "" + number;
                }

            }


            if (numberText.name == "PuntiForza")
            {
                stat.forza = number;
            }
            if (numberText.name == "PuntiAgilità")
            {
                stat.agilita = number;
            }
            if (numberText.name == "PuntiCostituzione")
            {
                stat.cost = number;
            }
            if (numberText.name == "PuntiIntelligenza")
            {
                stat.intel = number;
            }
            if (numberText.name == "PuntiPercezione")
            {
                stat.perc = number;
            }
            if (numberText.name == "PuntiFortuna")
            {
                stat.fortuna = number;
            }
        }
    }
}