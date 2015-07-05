using UnityEngine;
using System.Collections;
using com.erik.util;
using com.erik.training.model;
using com.erik.training.view;

namespace com.erik.training.controller{

	public class RS_Register : RunState {
		
		// Use this for initialization
		void Start () {
			
			ViewController.OnReady += HandleOnRegisterViewReady;
			ViewController.Instance.SetViewState (ViewState.VS_REGISTER);	
		}
		
		void HandleOnRegisterViewReady ()
		{
			ViewController.OnReady 	-= HandleOnRegisterViewReady;
			RegisterView.OnRegisterUserSuccess 	+= HandleOnRegisterUserSuccess;
		}
		
		void HandleOnRegisterUserSuccess (User userInfo)
		{
			RegisterUser (userInfo);

			RegisterView.OnRegisterUserSuccess 	-= HandleOnRegisterUserSuccess;
			nextState = typeof(RS_Home);
			GoNext ();
		}
		
		private void RegisterUser(User user)
		{
			Debug.Log ("Registering User Info ...");
			
			PlayerPrefs.SetString (Constants.USER_FIRST_NAME_KEY, user.firstName);
			PlayerPrefs.SetString (Constants.USER_LAST_NAME_KEY, user.lastName);
			PlayerPrefs.SetString (Constants.USER_EMAIL_KEY, user.email);
			
			PlayerPrefs.SetInt (Constants.APP_USE_STATE_KEY, 1);	
			
			Debug.Log ("User Registered ...");
		}
		
	}


}

