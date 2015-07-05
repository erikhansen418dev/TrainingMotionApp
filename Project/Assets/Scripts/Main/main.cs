using UnityEngine;
using System.Collections;
using com.erik.util;
using com.erik.training.controller;

public class main : MonoBehaviour {

	// Use this for initialization
	void Start () {

		TempClearHistory ();
		InitER ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void TempClearHistory()
	{
		PlayerPrefs.DeleteAll ();
	}

	void InitER()
	{
		ERSdkManager.OnReady += HandleOnERSdkReady;
		ERSdkManager.Instance.StartManager ();
	}

	void HandleOnERSdkReady ()
	{
		Debug.Log("ERSdk Initialized... Ready..");

		RunState.nextState = typeof(RS_Init);
		RunState.Done ();	
	}
}
