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
        
        GetComponent<Image>().gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
