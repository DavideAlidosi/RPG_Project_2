using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PotionMax : Item {

    

    

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
        equipPanel.SetActive(false);
        FindObjectOfType<Player>().hp = FindObjectOfType<Player>().hpMax;
    }
}
