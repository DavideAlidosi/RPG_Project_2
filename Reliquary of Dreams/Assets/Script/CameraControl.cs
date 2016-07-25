using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public GameObject playerPosition;
    public GameObject zoom;
    Vector3 zPos;
    bool isOnPlayer = true;

	// Use this for initialization
	void Start () {
        playerPosition = FindObjectOfType<Player>().gameObject;
        
        zPos = playerPosition.transform.position;
        zPos += new Vector3(0, 0, -10);
	}
	
	// Update is called once per frame
	void Update () {
        if (isOnPlayer)
        {
            zPos = playerPosition.transform.position;
            zPos += new Vector3(0, 0, -10);
            this.transform.position = Vector3.Lerp(this.transform.position, zPos, 0.25f);
            
        }
        else
        {
            zPos = zoom.transform.position;
            zPos += new Vector3(0, 0, -10);
            this.transform.position = Vector3.Lerp(this.transform.position, zPos, 0.25f);
            
        }
        
	}

    public void Zoom()
    {

        if (isOnPlayer)
        {
            isOnPlayer = false;
            GetComponent<Camera>().orthographicSize = Mathf.Lerp(8, 20, 1);
        }
        else
        {
            isOnPlayer = true;
            GetComponent<Camera>().orthographicSize = Mathf.Lerp(20, 8, 1);
        }
    }
}
