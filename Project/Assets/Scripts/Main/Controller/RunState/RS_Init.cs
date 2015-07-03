using UnityEngine;
using System.Collections;
using com.erik.util;
using com.erik.training.model;

namespace com.erik.training.controller{

	public class RS_Init : RunState {
		
		void Start()
		{
			Debug.Log("Start RS_Init");
			ViewController.OnReady += HandleOnViewControllerIsReady;
			ViewController _vc = ViewController.Instance;
		}
		
		void HandleOnViewControllerIsReady ()
		{
			ViewController.OnReady -= HandleOnViewControllerIsReady;
			
			if (IsFirstTime())
				OnFirstTime ();
			else
				OnNoFirstTime ();
		}
		
		
		private bool IsFirstTime()
		{
			int flag = PlayerPrefs.GetInt (Constants.APP_USE_STATE_KEY);
			Debug.Log ("firstTimeValue : " + flag);
			
			bool isFirst = true;
			if (flag == 1)
				isFirst = false;
			
			return isFirst;
		}
		
		
		private void OnFirstTime()
		{
			nextState = typeof(RS_Register);
			GoNext();
		}
		
		
		private void OnNoFirstTime()
		{
			nextState = typeof(RS_Home);
			GoNext ();
		}
	}

}
