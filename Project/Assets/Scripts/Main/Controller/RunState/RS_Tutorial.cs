using UnityEngine;
using System.Collections;
using com.erik.util;
using com.erik.training.model;
using com.erik.training.view;

namespace com.erik.training.controller{

	public class RS_Tutorial : RunState {
		
		// Use this for initialization
		void Start () {

			ViewController.OnReady += HandleOnTutorialViewReady;
			ViewController.Instance.SetViewState (ViewState.VS_TUTORIAL);				
		}

		void HandleOnTutorialViewReady ()
		{
			ViewController.OnReady -= HandleOnTutorialViewReady;
			TutorialView.OnPresentationCompleted += HandleOnTutorialPresentationCompleted;
			
		}

		void HandleOnTutorialPresentationCompleted ()
		{
			nextState = typeof(RS_Calibration);
			GoNext ();
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}

}

