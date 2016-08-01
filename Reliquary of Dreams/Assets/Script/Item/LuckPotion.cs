using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class LuckPotion : Item {

    
    public override void Drink()
    {
        FindObjectOfType<Player>().itemPlayer.RemoveAt(n);
        FindObjectOfType<Player>().forS += 2;
        FindObjectOfType<Player>().gcRef.potionTurnFor += 2;
        equipPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        Destroy(this.gameObject);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
