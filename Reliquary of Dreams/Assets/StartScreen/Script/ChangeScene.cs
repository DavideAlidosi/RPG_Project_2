using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour{

   public void ChangeToScene (string sceneToChangeTo) {
        Application.LoadLevel(sceneToChangeTo);

	}

    // start screen class
    public void StartGame()
    {
        SceneManager.LoadScene("Caggianelli");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
