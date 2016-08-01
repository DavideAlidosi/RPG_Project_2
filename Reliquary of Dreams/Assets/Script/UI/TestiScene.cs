using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestiScene : MonoBehaviour
{
    public int counterText = 1;
    public Text TextScene;
    public GameObject sprite;

    public void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Storia 1")
        {
            TextScene.text = "TEMPO:      allora Hend...";
        }
        if (SceneManager.GetActiveScene().name == "Storia 2")
        {
            TextScene.text = "TEMPO:      non e' troppo tardi per tornare indietro, Hend.";
        }
        if (SceneManager.GetActiveScene().name == "Storia 3")
        {
            TextScene.text = "TEMPO:       hai deciso di desistere o sei deciso ad andare fino in fondo?";
        }
        if (SceneManager.GetActiveScene().name == "Storia 4")
        {
            TextScene.text = "TEMPO:      ogni persona deve seguire il suo corso temporale, nessuno può sottrari.";
        }
        sprite.GetComponent<SpriteRenderer>().sprite = FindObjectOfType<Singleton>().player;
    }

    public void nextText ()
    {
        if (SceneManager.GetActiveScene().name == "Storia 1")
        {           
            if (counterText == 1)
            {
                TextScene.text = "HEND DEMISE:      Tempo!";
                counterText++;
            }
            else if (counterText == 2)
            {
                TextScene.text = "TEMPO:      stai venendo a vendicare Joshua, vero? Sai bene che la sua morte non e' stata colpa mia.";
                counterText++;
            }
            else if (counterText == 3)
            {
                TextScene.text = "HEND DEMISE:      zitto! Non mi importa chi sei... io ti cerchero', ti trovero' e... ti uccidero'.";
                counterText++;
            }
            else if (counterText == 4)
            {
                TextScene.text = "TEMPO:      oh Hend... sei libero di tentare. Coraggio, entra nella mia torre e vieni a trovarmi... se ci riesci.";
                counterText++;
            }
        }
        if (SceneManager.GetActiveScene().name == "Storia 2")
        {            
            if (counterText == 1)
            {
                TextScene.text = "HEND DEMISE:      mio fratello non tornera' in ogni caso, ma tu presto lo raggiungerai.";
                counterText++;
            }
            else if (counterText == 2)
            {
                TextScene.text = "TEMPO:      Joshua era malato da molto, non era possibile salvarlo. Non e' colpa di nessuno.";
                counterText++;
            }
            else if (counterText == 3)
            {
                TextScene.text = "HEND DEMISE:      nulla potra' impedirmi di arrivare a te, nemmeno i tuoi discorsi.";
                counterText++;
            }
            else if (counterText == 4)
            {
                TextScene.text = "TEMPO:      non tergiversare, allora! Vieni da me e concludiamo questa storia.";
                counterText++;
            }
        }
        if (SceneManager.GetActiveScene().name == "Storia 3")
        {
            if (counterText == 1)
            {
                TextScene.text = "HEND DEMISE:      Joshua non meritava di morire, non cosi' presto.";
                counterText++;
            }
            else if (counterText == 2)
            {
                TextScene.text = "TEMPO:      non dipende da me decidere chi vive e chi muore, il tempo scorre per tutti.";
                counterText++;
            }
            else if (counterText == 3)
            {
                TextScene.text = "HEND DEMISE:      n-non voglio ascoltarti. Non doveva finire cosi'!";
                counterText++;
            }
            else if (counterText == 4)
            {
                TextScene.text = "TEMPO:      desisti, sii ragionevole. Quello che stai facendo non fara' altro che ferirti!";
                counterText++;
            }
        }
        if (SceneManager.GetActiveScene().name == "Storia 4")
        {
            if (counterText == 1)
            {
                TextScene.text = "HEND DEMISE:      avrei dovuto trascorrere piu' tempo con lui. Ormai è tardi.";
                counterText++;
            }
            else if (counterText == 2)
            {
                TextScene.text = "TEMPO:       non puoi combattere il tempo, puoi solo trascorrere quello che hai con serenità";
                counterText++;
            }
            else if (counterText == 3)
            {
                TextScene.text = "HEND DEMISE:      ora capisco... troppo tardi ma capisco.";
                counterText++;
            }
            else if (counterText == 4)
            {
                TextScene.text = "TEMPO:       hai ancora tempo, Hend. Trascorrilo con le persone che ami senza sprecarne altro.";
                counterText++;
            }           
        }
        else if (counterText == 5)
        {
            counterText++;
        }
        else if (counterText == 6)
        {
            if (SceneManager.GetActiveScene().name == "Storia 1")
            {
                NextScene("Livello 1");
            }
            else if (SceneManager.GetActiveScene().name == "Storia 2")
            {
                NextScene("Livello 2");
            }
            else if (SceneManager.GetActiveScene().name == "Storia 3")
            {
                NextScene("Livello 3");
            }
        }
    }
    public void NextScene (string newScene)
    {
        SceneManager.LoadScene(newScene);
    }

}
