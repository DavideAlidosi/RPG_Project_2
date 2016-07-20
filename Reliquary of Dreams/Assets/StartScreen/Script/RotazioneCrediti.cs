using UnityEngine;
using System.Collections;

public class RotazioneCrediti : MonoBehaviour {

    public float speed = -10f; 
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, speed * Time.deltaTime);
	}

    public void AdjustSpeed (float newSpeed){
        speed = newSpeed;
    }
}
