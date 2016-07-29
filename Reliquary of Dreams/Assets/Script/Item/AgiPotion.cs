using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class AgiPotion : Item {
    public override void Drink()
    {
        FindObjectOfType<Player>().itemPlayer.RemoveAt(n);
        GetComponent<Image>().gameObject.SetActive(false);
        Destroy(this.gameObject);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
