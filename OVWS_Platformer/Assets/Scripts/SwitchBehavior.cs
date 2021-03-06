﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SwitchBehavior : NetworkBehaviour
{

    private Light solveIndicator;

    public float activateRadius = 1;
    [SyncVar]
    public bool activated;
    public bool puzzleSolved;

    public Color inactiveColor = Color.red;
    public Color activeColor = Color.yellow;
    public Color solvedColor = Color.green;

    public bool toggle;
    public bool pressure;
	
	public AudioClip switchFlip;
	public AudioClip switchActive;
	public AudioClip switchSolved;

	AudioSource audioOut;

    // Use this for initialization
    void Start()
    {
        puzzleSolved = false;
        solveIndicator = gameObject.GetComponentInChildren<Light>();
        solveIndicator.color = Color.red;

		audioOut = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (!puzzleSolved)
        {
            if (activated)
                solveIndicator.color = activeColor;
            else
                solveIndicator.color = inactiveColor;
        }
        //		if (!puzzleSolved)
        //		{
        //			GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        //
        //			for(int i = 0; i < players.Length; i++)
        //			{
        //				if((transform.position-players[i].transform.position).magnitude <= activateRadius)
        //				{
        //					activated = true;
        //					solveIndicator.color = activeColor;
        //					return;
        //				}
        //			}
        //
        //			activated = false;
        //			solveIndicator.color = inactiveColor;
        //		}
    }

    void OnTriggerEnter(Collider col)
    {
        if (!puzzleSolved)
        {
            if (col.gameObject.tag == "Player")
            {
                if (toggle)
				{
					audioOut.PlayOneShot(switchFlip, 0.6F);
					audioOut.PlayOneShot(switchActive, 0.8F);
                    activated = !activated;
/*                  if (activated)
                        solveIndicator.color = activeColor;
                    else
                        solveIndicator.color = inactiveColor;*/
                }
                if (pressure)
				{
					audioOut.PlayOneShot(switchFlip, 0.6F);
					audioOut.PlayOneShot(switchActive, 0.8F);
                    activated = true;
                    solveIndicator.color = activeColor;
				}
				if (isLocalPlayer)
				{
					CmdSyncActivatedValue(activated);
				}
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (!puzzleSolved)
        {
            if (col.gameObject.tag == "Player")
            {
                //			if(toggle)
                //			{
                //
                //			}
                if (pressure)
                {
                    activated = false;
                    solveIndicator.color = inactiveColor;
                }
                if (isLocalPlayer)
				{
                    CmdSyncActivatedValue(activated);
				}
            }
        }
    }

    public void solvePuzzle()
    {
		audioOut.PlayOneShot (switchSolved, 0.8F);
        puzzleSolved = true;
        solveIndicator.color = solvedColor;
    }

    public void unSolvePuzzle()
    {
        puzzleSolved = false;
        solveIndicator.color = inactiveColor;
    }

    [Command]
    public void CmdSyncActivatedValue(bool activeState)
    {
        activated = activeState;
    }
}
