﻿using UnityEngine;
using System.Collections;

public class PuzzleManager6 : MonoBehaviour {

	public GameObject movingPlatform, switchOne, switchTwo;
	Vector3 initialPos;
	Vector3 downPos;
	Vector3 leftPos;
	Vector3 targetPos, currentPos;

	private SwitchBehavior switchOneStatus, switchTwoStatus;

	// Use this for initialization
	void Start () {
		initialPos = movingPlatform.transform.position;
		downPos = new Vector3(initialPos.x, initialPos.y - 26.0f, initialPos.z);
		leftPos = new Vector3(initialPos.x - 20.0f, initialPos.y, initialPos.z);
		switchOneStatus = switchOne.GetComponent<SwitchBehavior> ();
		switchTwoStatus = switchTwo.GetComponent<SwitchBehavior> ();
	}
	
	// Update is called once per frame
	void Update () {
		currentPos = movingPlatform.transform.position;
//		if(switchOneStatus.activated && Mathf.Round(movingPlatform.transform.position.x) == downPos.x)
//		{
//			movingPlatform.transform.position = Vector3.Lerp(movingPlatform.transform.position, downPos, Time.deltaTime);
//		}
//		else if(switchTwoStatus.activated && Mathf.Round(movingPlatform.transform.position.y) == leftPos.y)
//		{
//			movingPlatform.transform.position = Vector3.Lerp(movingPlatform.transform.position, leftPos, Time.deltaTime);
//		}
//		else
//		{
//			movingPlatform.transform.position = Vector3.Lerp(movingPlatform.transform.position, initialPos, Time.deltaTime);
//		}
		if(switchOneStatus.activated && Mathf.Round(currentPos.x) == downPos.x)
		{
			targetPos = downPos;
		}
		else if(switchTwoStatus.activated && Mathf.Round(currentPos.y) == leftPos.y)
		{
			targetPos = leftPos;
		}
		else
		{
			targetPos = initialPos;
		}
		movingPlatform.transform.position = Vector3.MoveTowards(currentPos, targetPos, Time.deltaTime * 10.0f);
	}
}
