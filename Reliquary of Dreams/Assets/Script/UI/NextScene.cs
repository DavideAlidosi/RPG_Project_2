using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {
    StoryTeller refST;
    public Animator door;
    public Animator doorsx;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void NextLevel()
    {

        StartCoroutine(AnimationDoor());
        
    }

    IEnumerator AnimationDoor()
    {
        door.SetBool("Active", true);
        doorsx.SetBool("Active", true);
        yield return new WaitForSeconds(2.2f);
        door.SetBool("Active", false);
        doorsx.SetBool("Active", false);
        refST = FindObjectOfType<StoryTeller>();
        SceneManager.LoadScene(refST.sceneToLoad);
        refST.sceneToLoad += 2;
        
    }
}
