using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUp : MonoBehaviour {

    public Image tooltipPanel;
    ShowTool refShowTool;


    // Use this for initialization
    void Start() {
        refShowTool = FindObjectOfType<ShowTool>();
        tooltipPanel = refShowTool.GetComponent<Image>();
        DeactivateTooltip();
    }

    void OnMouseEnter()
    {
        
        if (GetComponentInChildren<Player>())
        {
            ActivateTooltip();
            refShowTool.strTxt.text = "Str : " + GetComponentInChildren<Player>().str;
            refShowTool.cosTxt.text = "Agi : " + GetComponentInChildren<Player>().agi;
            refShowTool.hpTxt.text = "HP : " + GetComponentInChildren<Player>().hp;
        }

        if (GetComponentInChildren<Enemy>())
        {
            ActivateTooltip();
            refShowTool.strTxt.text = "Str : " + GetComponentInChildren<Enemy>().str;
            refShowTool.cosTxt.text = "Agi : " + GetComponentInChildren<Enemy>().agi;
            refShowTool.hpTxt.text = "HP : " + GetComponentInChildren<Enemy>().hp;

            this.GetComponentInChildren<Enemy>().LookingCell();
            

        }

    }

    void OnMouseExit()
    {
        
        DeactivateTooltip();
        if (this.GetComponentInChildren<Enemy>())
        {
            this.GetComponentInChildren<Enemy>().ResetLookingCell();
            foreach (var cell in FindObjectOfType<FogOfWar>().destroyCell)
            {
                if (cell.GetComponent<SpriteRenderer>().color != Color.red)
                {
                    cell.GetComponent<SpriteRenderer>().color = Color.blue;
                }
                
                
            }
        }
        
    }

    // Update is called once per frame
    void Update() {

    }

    void DeactivateTooltip()
    {
        tooltipPanel.enabled = false;
        refShowTool.strTxt.enabled = false;
        refShowTool.hpTxt.enabled = false;
        refShowTool.cosTxt.enabled = false;
    }
    void ActivateTooltip()
    {
        tooltipPanel.enabled = true;
        refShowTool.strTxt.enabled = true;
        refShowTool.hpTxt.enabled = true;
        refShowTool.cosTxt.enabled = true;
    }
}
