using UnityEngine;
using System.Collections;
using System;

public class StrPotion : Item {

   

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Drink()
    {
        FindObjectOfType<Player>().itemPlayer.RemoveAt(n);
        inventoryPanel.SetActive(false);
        Destroy(this.gameObject);
    }
}
