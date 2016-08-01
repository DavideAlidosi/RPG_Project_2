using UnityEngine;
using System.Collections;
public enum TextLevel { T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22 }
public class StoryTeller : MonoBehaviour {
    public TextLevel dialogoN = TextLevel.T1;

    public int sceneToLoad = 3;
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
