using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Setstat : MonoBehaviour
{
    ChangeScene refChange;
    Singleton stat;
    public Text forz;
    public Text agi;
    public Text cos;
    public Text per;
    public Text fortu;

    public void setStatsBandito()
    {
        refChange = FindObjectOfType<ChangeScene>();
        stat = FindObjectOfType<Singleton>();

        forz.text = "4";
        agi.text = "5";
        cos.text = "4";
        per.text = "5";
        fortu.text = "3";

        stat.forza = 4;
        stat.agilita = 5;
        stat.cost = 4;
        stat.perc = 5;
        stat.fortuna = 3;
    }

    public void setStatsCavaliere()
    {
        refChange = FindObjectOfType<ChangeScene>();
        stat = FindObjectOfType<Singleton>();

        forz.text = "3";
        agi.text = "3";
        cos.text = "7";
        per.text = "6";
        fortu.text = "6";

        stat.forza = 3;
        stat.agilita = 3;
        stat.cost = 7;
        stat.perc = 6;
        stat.fortuna = 6;

    }


    public void setStatsLadro()
    {
        refChange = FindObjectOfType<ChangeScene>();
        stat = FindObjectOfType<Singleton>();

        forz.text = "4";
        agi.text = "7";
        cos.text = "3";
        per.text = "2";
        fortu.text = "7";

        stat.forza = 4;
        stat.agilita = 7;
        stat.cost = 3;
        stat.perc = 2;
        stat.fortuna = 7;

    }


    public void setStatsGuerriero()
    {
        refChange = FindObjectOfType<ChangeScene>();
        stat = FindObjectOfType<Singleton>();

        forz.text = "7";
        agi.text = "4";
        cos.text = "4";
        per.text = "6";
        fortu.text = "3";

        stat.forza = 7;
        stat.agilita = 4;
        stat.cost = 4;
        stat.perc = 6;
        stat.fortuna = 3;

    }
}