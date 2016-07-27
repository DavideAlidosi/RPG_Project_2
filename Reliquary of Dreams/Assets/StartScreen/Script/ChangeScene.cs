using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public Text pointText;
    public int point = 24;
    public int forza;
    public int agilita;
    public int cost;
    public int intel;
    public int perc;
    public int fortuna;

    public bool changeStat = true;
    public GameObject alert;



    public void ChangeToScene (string sceneToChangeTo) {

        if (SceneManager.GetActiveScene().name == "PopUpConfermaStats")
        {
            FindObjectOfType<AudioSource>().Stop();
        }

        if (SceneManager.GetActiveScene().name == "StatsDistribution")
        {
            if (point == 0)
            {
                SceneManager.LoadScene(sceneToChangeTo);
            }
            else
            {
                SceneManager.LoadScene("PopUpConfermaAvanti");
            }
        }
        else
        {
            SceneManager.LoadScene(sceneToChangeTo);
        }

        
    }
    public void BackToScene (string sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RemoveIt()
    {
        alert.SetActive(false);
        changeStat = true;
    }

}
