using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum TextLevel { T1, T2, T3, T4, T5, T6, T7, T8,T9,T10,T11,T12,T13,T14,T15,T16,T17,T18,T19,T20,T21,T22 }

public class MenuPopUp : MonoBehaviour {
    public GameObject menuPanel;

    bool isActive = false;
    public Image inventory;
    public Text dialoghi;
    public GameObject panelDialoghi;

    public TextLevel dialogoN = TextLevel.T1;

    
	// Use this for initialization
    void Awake ()
    {
        
    }

	void Start () {

        

    }
    
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Activate()
    {
        menuPanel.SetActive(true);
    }

    public void Deactivate()
    {
        menuPanel.SetActive(false);
    }

    public void ConsumableInventory()
    {
        if (!isActive)
        {
            inventory.gameObject.SetActive(true);
            isActive = true;
        }
        else
        {
            inventory.gameObject.SetActive(false);
            isActive = false;
        }
        
    }
}
