using UnityEngine;
using System.Collections;
using com.erik.util;
using com.erik.training.model;
using com.erik.training.view;

namespace com.erik.training.controller{

	public class RS_Home : RunState {
		
		// Use this for initialization
		void Start () {
			
			Debug.Log("RS_Home start");
			
			ViewController.OnReady += HandleOnHomeViewReady;
			ViewController.Instance.SetViewState (ViewState.VS_HOME);
		}
		
		void HandleOnHomeViewReady ()
		{
			ViewController.OnReady -= HandleOnHomeViewReady;
			HomeView.OnEnterExercise += HandleOnEnterExercise;
			
			GetUserInfo ();	
		}

		void HandleOnEnterExercise (int index)
		{

			nextState = typeof(RS_Tutorial);
			GoNext ();
		}
		
		void GetUserInfo()
		{
			Debug.Log ("Getting UserInfo ...");
			
			User user = new User (); 	
			user.firstName 	= PlayerPrefs.GetString (Constants.USER_FIRST_NAME_KEY);
			user.lastName 	= PlayerPrefs.GetString (Constants.USER_LAST_NAME_KEY);
			user.email		= PlayerPrefs.GetString (Constants.USER_EMAIL_KEY);
			
			UserData.SetUser (user);
			
			Debug.Log("Finished Getting UserInfo...");
			Debug.Log ("user info : " + UserData.user.ToString());
		}
		
		
	}

}

