using UnityEngine;
using System.Collections;
using com.erik.util;
using com.erik.training.controller;
using com.erik.training.model;

public class main : MonoBehaviour {

	public string smtpClient;
	public string senderEmailAddr;
	public string password;

	// Use this for initialization
	void Start () {

//		TempClearHistory ();
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
		ERSdkManager.OnReady -= HandleOnERSdkReady;

		RunState.nextState = typeof(RS_Init);
		RunState.Done ();	
	}
}
