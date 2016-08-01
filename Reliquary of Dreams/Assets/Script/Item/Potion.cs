using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Potion : Item {

    
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
        equipPanel.SetActive(false);
        Destroy(this.gameObject);
        int temp =  FindObjectOfType<Player>().hpMax / 2;
        if (temp + FindObjectOfType<Player>().hp > FindObjectOfType<Player>().hpMax)
        {
            FindObjectOfType<Player>().hp = FindObjectOfType<Player>().hpMax;
        }
        else
        {
            FindObjectOfType<Player>().hp += temp;
        }
        
    }
}
