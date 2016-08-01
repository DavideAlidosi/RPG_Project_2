using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestiScene : MonoBehaviour
{
    public int counterText = 1;
    public Text TextScene;

    public void nextText ()
    {
        if (counterText == 1)
        {
            TextScene.text = "1";
            counterText++;
        }
        else if (counterText == 2)
        {
            TextScene.text = "2";
            counterText++;
        }
        else if (counterText == 3)
        {
            TextScene.text = "3";
            counterText++;
        }
        else if (counterText ==4)
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
