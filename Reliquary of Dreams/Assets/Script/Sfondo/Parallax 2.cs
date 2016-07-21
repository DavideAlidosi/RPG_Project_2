﻿using UnityEngine;
using System.Collections;

public class Parallax2 : MonoBehaviour {

    public float scrollSpeed;
    private Vector2 savedOffset;
    
    // Use this for initialization
	void Start ()
    {
        savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset("_MainTex");
    }
	
	// Update is called once per frame
	void Update ()
    {
        float y = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(savedOffset.x, y);       
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);

    }
}
