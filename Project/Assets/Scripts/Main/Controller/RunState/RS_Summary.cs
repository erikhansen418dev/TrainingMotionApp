using UnityEngine;
using System.Collections;
using com.erik.util;
using com.erik.training.model;
using com.erik.training.view;


namespace com.erik.training.controller
{
	public class RS_Summary : RunState {
		
		// Use this for initialization
		void Start () {
			
			ViewController.OnReady += HandleOnSummaryViewReady;
			ViewController.Instance.SetViewState (ViewState.VS_SUMMARY);
			
		}

		void HandleOnSummaryViewReady ()
		{
			ViewController.OnReady -= HandleOnSummaryViewReady;
			SummaryView.OnGOHome += HandleOnGOHome;
		}

		void HandleOnGOHome ()
		{
			SummaryView.OnGOHome -= HandleOnGOHome;
			nextState = typeof(RS_Home);
			GoNext ();
		}	
		
	}
}

