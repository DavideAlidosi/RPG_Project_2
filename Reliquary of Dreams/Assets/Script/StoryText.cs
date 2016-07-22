using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
enum TextLevel { N1,N2,N3,N4,N5,N6,N7,N8 }

public class StoryText : MonoBehaviour {

    GameControl refGC = FindObjectOfType<GameControl>();
    TextLevel text = TextLevel.N1;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpamText()
    {
        if (text == TextLevel.N1)
        {
            Debug.Log("Ciaoaoaoaoaoa");
            text++;
        }
        else if (text == TextLevel.N2)
        {
            text++;
            Debug.Log("prprprpr");
        }
        else if (text == TextLevel.N3)
        {
            text++;
            Debug.Log("f1f1f1f");
        }
    }
}
