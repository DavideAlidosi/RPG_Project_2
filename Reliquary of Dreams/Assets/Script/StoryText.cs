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
        else if (refStoryTeller.dialogoN == TextLevel.T3)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            TerzoDialogo();
            

        }
        else if (refStoryTeller.dialogoN == TextLevel.T4)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            QuartoDialogo();

        }
        else if (refStoryTeller.dialogoN == TextLevel.T5)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            QuintoDialogo();

        }
        else if (refStoryTeller.dialogoN == TextLevel.T6)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            SestoDialogo();

        }
        else if (refStoryTeller.dialogoN == TextLevel.T7)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            SettimoDialogo();

        }
        else if (refStoryTeller.dialogoN == TextLevel.T8)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            OttavoDialogo();

        }
        else if (refStoryTeller.dialogoN == TextLevel.T9)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            NonoDialogo();

        }
        else if (refStoryTeller.dialogoN == TextLevel.T10)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            DecimoDialogo();

        }
        else if (refStoryTeller.dialogoN == TextLevel.T11)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            UndicesimoDialogo();

        }
        else if (refStoryTeller.dialogoN == TextLevel.T12)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            DodicesimoDialogo();

        }
        else if (refStoryTeller.dialogoN == TextLevel.T13)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            TredicesimoDialogo();

        }
        else if (refStoryTeller.dialogoN == TextLevel.T14)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            QuattordicesimoDialogo();

        }
        else if (refStoryTeller.dialogoN == TextLevel.T15)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            QuindicesimoDialogo();

        }
        else if (refStoryTeller.dialogoN == TextLevel.T16)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            SedicesimoDialogo();

        }
        else if (refStoryTeller.dialogoN == TextLevel.T17)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            DiciasettesimoDialogo();

        }
        else if (refStoryTeller.dialogoN == TextLevel.T18)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            DiciottesimoDialogo();

        }
        else if (refStoryTeller.dialogoN == TextLevel.T19)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            DiciannovesimoDialogo();

        }
        else if (refStoryTeller.dialogoN == TextLevel.T20)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            VentesimoDialogo();

        }
        else if (refStoryTeller.dialogoN == TextLevel.T21)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            VentunesimoDialogo();

        }
        else if (refStoryTeller.dialogoN == TextLevel.T22)
        {
            refStoryTeller.dialogoN++;
            refGC.phase = GamePhase.Dialoghi;
            VentiduesimoDialogo();

        }
    }

    void PrimoDialogo()
    {
        
        refMenu.dialoghi.text = "Demise non ricorda, Demise non accetta la verita'";
    }

    void SecondoDialogo()
    {
        refMenu.dialoghi.text = "Hend Demaise e' un eroe che ha deciso di non lasciarsi sopraffare";
    }

    void TerzoDialogo()
    {
        refMenu.dialoghi.text = "La mente e' annebbiata e la mancanza di qualcosa prende piede… o di qualcuno";
    }

    void QuartoDialogo()
    {
        refMenu.dialoghi.text = "In cerca di una forza pressante che non lascia scampo";
    }

    void QuintoDialogo()
    {
        refMenu.dialoghi.text = "Piu' veloce, ogni secondo e' prezioso";
    }

    void SestoDialogo()
    {
        refMenu.dialoghi.text = "Hend avanza nella grande torre, verso cosa? Perche'?";
    }

    void SettimoDialogo()
    {
        refMenu.dialoghi.text = "Il respiro affannoso, la mente occultata e una voce in lontananza… soave rimbomba nella sua testa";
    }

    void OttavoDialogo()
    {
        refMenu.dialoghi.text = "Le domande sono d’obbligo. Forse le risposte non sono così importanti al fin dei conti";
    }

    void NonoDialogo()
    {
        refMenu.dialoghi.text = "Ecco la porta verso il buio… luce accecante negli occhi, nero pece nel cuore";
    }

    void DecimoDialogo()
    {
        refMenu.dialoghi.text = "Tempo. Quanto ne rimane e' un mistero. Che volto ha e' certezza";
    }

    void UndicesimoDialogo()
    {
        refMenu.dialoghi.text = "Un ricordo e' sfuggito. Una parte e' recuperata. Hend ha uno scopo e l’angoscia di non sapere se vuole ricordare";
    }

    void DodicesimoDialogo()
    {
        refMenu.dialoghi.text = "Qualcosa affiora… Hend Demise sente la mancanza del suo amico";
    }

    void TredicesimoDialogo()
    {
        refMenu.dialoghi.text = "Deve avanzare con i suoi dubbi e le sue paure";
    }

    void QuattordicesimoDialogo()
    {
        refMenu.dialoghi.text = "Ascolta il suo cuore e vede dentro di se qualcosa di misterioso, tre luci… una risplende di rosso";
    }

    void QuindicesimoDialogo()
    {
        refMenu.dialoghi.text = "Il vento tra i capelli e i battiti feroci nel petto";
    }

    void SedicesimoDialogo()
    {
        refMenu.dialoghi.text = "Cosa sono quelle lunghe distese grigie? Asfalto?";
    }

    void DiciasettesimoDialogo()
    {
        refMenu.dialoghi.text = "Nella testa di Hend prende forma l’idea che quello che sta vivendo non e' la realtà. Cos’e' quel marchingegno dentro il quale e' seduto? ";
    }

    void DiciottesimoDialogo()
    {
        refMenu.dialoghi.text = "Angoscia e terrore, sensazioni forti legate alla velocita'. Lentamente qualcosa affiora";
    }

    void DiciannovesimoDialogo()
    {
        refMenu.dialoghi.text = "Un auto, un compagno. L’amico di una vita, un esistenza fragile e delicata";
    }

    void VentesimoDialogo()
    {
        refMenu.dialoghi.text = "Questa non e' la realta', ora e' chiaro. Allora dov’e' Hend? Chi e' Hend?";
    }

    void VentunesimoDialogo()
    {
        refMenu.dialoghi.text = "Qualcosa ha mutato la percezione del reale e del fantastico. La scintilla che ha acceso il fuoco di quest’avventura";
    }

    void VentiduesimoDialogo()
    {
        refMenu.dialoghi.text = "E infine la morale. Un insegnamento che e' possibile comprendere solo con il tempo, solo dal “Tempo”";
    }


    public void StopDialogo()
    {
        refMenu = FindObjectOfType<MenuPopUp>();
        refGC = FindObjectOfType<GameControl>();
        refMenu.panelDialoghi.SetActive(false);
        refGC.phase = GamePhase.Movimento;
    }
}
