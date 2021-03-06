﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class LevelEnd : NetworkBehaviour
{
	public Light triggerLight;
	public string nextLevel;

	CustomNetworkManager netManager;
	int playersAtEnd;

	private AudioSource audioOut;
	public AudioClip levelEnd;

	public GameObject menuHolder;

	void Start ()
	{
		playersAtEnd = 0;
		netManager = GameObject.FindGameObjectWithTag("NetManager").GetComponent<CustomNetworkManager>();
		audioOut = GetComponent<AudioSource> ();
	}

	void Update () {
		// activates new scene when all players gather on this object
		if (playersAtEnd == 2)
		{
			audioOut.PlayOneShot(levelEnd, 0.7F);
			//Fix Control Menu
			//menuHolder.SetActive(true);	

			//Application.LoadLevel(1);
			netManager.ServerChangeScene(nextLevel);
		}
	}

	void OnTriggerEnter(Collider other) {
		triggerLight.intensity = 4;
		if(other.gameObject.CompareTag("Player"))
		{
			playersAtEnd++;
		}
	}
	void OnTriggerExit(Collider other) {
		triggerLight.intensity = 2;
		if(other.gameObject.CompareTag("Player"))
		{
			playersAtEnd--;
		}
	}
}
