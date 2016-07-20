using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour{

    public void ChangeToScene (string sceneToChangeTo) {
        SceneManager.LoadScene(sceneToChangeTo);

	}


    public void QuitGame()
    {
        Application.Quit();
    }
}
