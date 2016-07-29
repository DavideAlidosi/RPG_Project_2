using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class StoryText : MonoBehaviour {

    MenuPopUp refMenu;
    GameControl refGC;
    StoryTeller refStoryTeller;
    public bool find = false;
    
	// Use this for initialization
	void Start () {
        refGC = FindObjectOfType<GameControl>();
        
        
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void SpamText()
    {
        refStoryTeller = FindObjectOfType<StoryTeller>();
        refMenu = FindObjectOfType<MenuPopUp>();
        refGC = FindObjectOfType<GameControl>();
        refMenu.panelDialoghi.SetActive(true);
        
        if (refStoryTeller.dialogoN == TextLevel.T1)
        {
            refGC.phase = GamePhase.Dialoghi;
            refStoryTeller.dialogoN++;
            PrimoDialogo();
        }
        else if (refStoryTeller.dialogoN == TextLevel.T2)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            SecondoDialogo();
        }
        
    }

    void PrimoDialogo()
    {
        
        refMenu.dialoghi.text = "Puoi attaccare premendo con il tasto sinistro sul nemico. Il personaggio si avvicinera' a lui e lo provera' a colpire.";
    }

    void SecondoDialogo()
    {
        refMenu.dialoghi.text = "Premere con il tasto sinistro su un oggetto per interagirci.";
    }

    public void StopDialogo()
    {
        refMenu = FindObjectOfType<MenuPopUp>();
        refGC = FindObjectOfType<GameControl>();
        refMenu.panelDialoghi.SetActive(false);
        refGC.phase = GamePhase.Movimento;
    }
}
