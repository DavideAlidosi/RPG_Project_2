﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class AgiPotion : Item {
    public override void Drink()
    {
        FindObjectOfType<Player>().itemPlayer.RemoveAt(n);
        inventoryPanel.SetActive(false);
        equipPanel.SetActive(false);
        Destroy(this.gameObject);
        FindObjectOfType<Player>().agi += 2;
        FindObjectOfType<Player>().gcRef.potionTurnAgi += 2;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
