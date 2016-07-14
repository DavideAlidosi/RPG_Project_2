using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuPopUp : MonoBehaviour {
    public GameObject menuPanel;
    

    
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
}
