﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonThing : MonoBehaviour
{
	private ControlManager controlObject;
	private bool isBeingRemapped;

	[SerializeField]
	private PlayerActions actionToSet;

	// Use this for initialization
	void Start ()
	{
		controlObject = GameObject.Find("Game Manager").GetComponent<ControlManager>();
		isBeingRemapped = false;
		UpdateText ();
	}

	void OnGUI()
	{
		if(isBeingRemapped && (Event.current.isKey || Event.current.isMouse))
		{
			if(Event.current.isKey)
			{
				controlObject.SetControl(actionToSet, Event.current.keyCode);
				gameObject.GetComponentInChildren<Text>().text = Event.current.keyCode.ToString();
			}
			else if(Event.current.isMouse)
			{
				KeyCode kc = KeyCode.Mouse0+Event.current.button;
				controlObject.SetControl(actionToSet, kc);
				gameObject.GetComponentInChildren<Text>().text = kc.ToString();
			}
			isBeingRemapped = false;
		}
	}

	public void UpdateText()
	{
		gameObject.GetComponentInChildren<Text>().text = controlObject.GetControl(actionToSet).ToString();
	}

	public void ButtonToggle()
	{
		//if we were smart we'd disable the ability to host/join a game here and re-enable it in OnGUI. Too bad we're not clever enough to think of that.
		isBeingRemapped = true;
		gameObject.GetComponentInChildren<Text>().text = "[...]";
	}
}
