using UnityEngine;
using System.Collections;
using com.erik.util;
using com.erik.training.controller;
using com.erik.training.model;

public class main : MonoBehaviour {

	public string smtpClient;
	public string senderEmailAddr;
	public string password;

	public string gesturesFolderName;
	public string gifFolderName;

	// Use this for initialization
	void Start () {

		SetSettings ();
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

	void SetSettings()
	{
		if (! string.IsNullOrEmpty (smtpClient))
			Settings.smtpClient = smtpClient;

		if (! string.IsNullOrEmpty (senderEmailAddr))
			Settings.senderEmailAddr = senderEmailAddr;

		if (! string.IsNullOrEmpty (password))
			Settings.password = password;

		if (! string.IsNullOrEmpty (gesturesFolderName))
			Settings.gestureFolderPath = System.IO.Path.Combine(Application.streamingAssetsPath , gesturesFolderName);
		
		if (! string.IsNullOrEmpty (gifFolderName))
			Settings.gifAnimationFolderPath = System.IO.Path.Combine(Application.streamingAssetsPath , gifFolderName);
	}
}
