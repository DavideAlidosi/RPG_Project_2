﻿using UnityEngine;
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
            refShowTool.cosTxt.text = "Cos : " + GetComponentInChildren<Player>().cos;
            refShowTool.agiTxt.text = "Agi : " + GetComponentInChildren<Player>().agi;
            refShowTool.hpTxt.text = "HP : " + GetComponentInChildren<Player>().hp;
            refShowTool.intTxt.text = "Per : " + GetComponentInChildren<Player>().per;
            refShowTool.perTxt.text = "Int : " + GetComponentInChildren<Player>().intS;
            refShowTool.forTxt.text = "For : " + GetComponentInChildren<Player>().forS;
        }

        if (GetComponentInChildren<Enemy>() && GetComponentInChildren<Enemy>().gameObject.GetComponent<SpriteRenderer>().color != Color.clear)
        {
            ActivateTooltip();
            refShowTool.strTxt.text = "Str : " + GetComponentInChildren<Enemy>().str;
            refShowTool.cosTxt.text = "Cos : " + GetComponentInChildren<Enemy>().cos;
            refShowTool.agiTxt.text = "Agi : " + GetComponentInChildren<Enemy>().agi;
            refShowTool.hpTxt.text = "HP : " + GetComponentInChildren<Enemy>().hp;
            refShowTool.intTxt.text = "Per : " + GetComponentInChildren<Enemy>().intS;
            refShowTool.perTxt.text = "Int : " + GetComponentInChildren<Enemy>().per;
            refShowTool.forTxt.text = "For : " + GetComponentInChildren<Enemy>().forS;

            this.GetComponentInChildren<Enemy>().LookingCell();
            
            

        }

    }

    void OnMouseExit()
    {
        
        DeactivateTooltip();
        if (this.GetComponentInChildren<Enemy>() && GetComponentInChildren<Enemy>().gameObject.GetComponent<SpriteRenderer>().color != Color.clear)
        {
            this.GetComponentInChildren<Enemy>().ResetLookingCell();
            foreach (var cell in FindObjectOfType<FogOfWar>().destroyCell)
            {
                if (cell.refMyTile.color != Color.red)
                {
                    cell.refMyTile.color = Color.green;
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
        refShowTool.intTxt.enabled = false;
        refShowTool.perTxt.enabled = false;
        refShowTool.agiTxt.enabled = false;
        refShowTool.forTxt.enabled = false;
    }
    void ActivateTooltip()
    {
        tooltipPanel.enabled = true;
        refShowTool.strTxt.enabled = true;
        refShowTool.hpTxt.enabled = true;
        refShowTool.cosTxt.enabled = true;
        refShowTool.intTxt.enabled = true;
        refShowTool.perTxt.enabled = true;
        refShowTool.agiTxt.enabled = true;
        refShowTool.forTxt.enabled = true;
    }
}
