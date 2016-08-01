using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {
    StoryTeller refST;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void NextLevel()
    {
        refST = FindObjectOfType<StoryTeller>();
        
        SceneManager.LoadScene(refST.sceneToLoad);
        refST.sceneToLoad += 2;
    }
}
