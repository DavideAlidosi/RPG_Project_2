using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour {
    Player refPl;
    public Text strText;
    public Text agiText;
    public Text cosText;
    public Text intText;
    public Text perText;
    public Text forText;
    int pointToSpend;

    public 
	// Use this for initialization
	void Start () {
        refPl = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Continue()
    {
        if (pointToSpend < 1)
        {
            this.gameObject.SetActive(false);
        }
        
    }

    void OnEnable()
    {
        refPl = FindObjectOfType<Player>();
        pointToSpend = 1;
        strText.text = "" + refPl.str;
        agiText.text = "" + refPl.agi;
        cosText.text = "" + refPl.cos;
        intText.text = "" + refPl.intS;
        perText.text = "" + refPl.per;
        forText.text = "" + refPl.forS;
    }

    public void ClickStat(GameObject buttonName)
    {
        if (pointToSpend > 0)
        {
            int temp;
            int.TryParse(buttonName.GetComponent<Text>().text, out temp);
            Debug.Log(temp);
            buttonName.GetComponent<Text>().text = "" + temp++;
            pointToSpend--;
        }
        
    }
}
