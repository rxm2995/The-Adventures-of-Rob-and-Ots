﻿using UnityEngine;
using System.Collections;

public class MinimapBehavior : MonoBehaviour {

	public RectTransform panel;
	private Camera thisCamera;
	float lastScreenHeight;
	float lastScreenWidth;
	Player playerRef;

	// Use this for initialization
	void Start () {
		panel = GameObject.FindGameObjectWithTag ("Minimap Panel").GetComponent<RectTransform>();
		thisCamera = GetComponent<Camera>();
		thisCamera.aspect = (Screen.width/Screen.height);
		panel.sizeDelta = new Vector2(thisCamera.aspect * Screen.width * 1.05f, thisCamera.aspect * Screen.height * 1.05f); 
		lastScreenWidth = Screen.width;
		lastScreenHeight = Screen.height;
	}
	
	// Update is called once per frame
	void Update () {

		if(lastScreenWidth != Screen.width || lastScreenHeight != Screen.height)
		{
			lastScreenWidth = Screen.width;
			lastScreenHeight = Screen.height;
			thisCamera.aspect = (Screen.width/Screen.height);
			panel.sizeDelta = new Vector2(thisCamera.aspect * Screen.width * 1.05f, thisCamera.aspect * Screen.height * 1.05f); 
		}
	}
}
