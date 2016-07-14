using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public GameObject playerPosition;
    Vector3 zPos;

	// Use this for initialization
	void Start () {
        zPos = playerPosition.transform.position;
        zPos += new Vector3(0, 0, -10);
	}
	
	// Update is called once per frame
	void Update () {
        zPos = playerPosition.transform.position;
        zPos += new Vector3(0, 0, -10);
        this.transform.position = Vector3.Lerp(this.transform.position, zPos, 0.25f);
	}
}
