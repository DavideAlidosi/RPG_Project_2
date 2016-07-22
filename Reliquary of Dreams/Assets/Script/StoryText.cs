using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class StoryText : MonoBehaviour {

    MenuPopUp refMenu;
    GameControl refGC;
    
	// Use this for initialization
	void Start () {
        refGC = FindObjectOfType<GameControl>();
        refMenu = FindObjectOfType<MenuPopUp>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void SpamText()
    {
        refMenu.panelDialoghi.SetActive(true);
        if (refMenu.dialogoN == TextLevel.T1)
        {
            refGC.phase = GamePhase.Dialoghi;
            refMenu.dialogoN++;

            PrimoDialogo();
        }
        else if (refMenu.dialogoN == TextLevel.T2)
        {
            refMenu.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            SecondoDialogo();

        }
        else if (refMenu.dialogoN == TextLevel.T3)
        {
            refMenu.dialogoN++;
            Debug.Log("f1f1f1f");
        }
    }

    void PrimoDialogo()
    {
        
        refMenu.dialoghi.text = "IASDHFOIAUSDHFIOAUSHDFOIUASHDFIUADSHFAUISD";
    }

    void SecondoDialogo()
    {
        refMenu.dialoghi.text = "PIPPO FA LE PIPPE A PIPPA";
    }


    public void StopDialogo()
    {
        refMenu = FindObjectOfType<MenuPopUp>();
        refGC = FindObjectOfType<GameControl>();
        refMenu.panelDialoghi.SetActive(false);
        refGC.phase = GamePhase.Selezione;
    }
}
