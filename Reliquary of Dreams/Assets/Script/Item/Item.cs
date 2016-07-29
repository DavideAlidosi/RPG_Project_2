using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour {

    public int n;
    public GameObject inventoryPanel;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public abstract void Drink();
    
}
