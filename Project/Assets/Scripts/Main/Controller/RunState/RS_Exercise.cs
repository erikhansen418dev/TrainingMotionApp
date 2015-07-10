using UnityEngine;
using System.Collections;
using com.erik.util;
using com.erik.training.view;
using com.erik.training.model;

namespace com.erik.training.controller
{
	public class RS_Exercise : RunState {
		
		// Use this for initialization
		void Start () {

			ViewController.OnReady += HandleOnExerciseViewReady;
			ViewController.Instance.SetViewState (ViewState.VS_EXERCISE);
		}

		void HandleOnExerciseViewReady ()
		{
			ViewController.OnReady -= HandleOnExerciseViewReady;
			ERSdkManager.OnReady += HandleOnERSDKReady;

			string gestureFileName = DataController.Instance.GetData ().gestureFilePath;
			ERSdkManager.Instance.SetGestureFile (gestureFileName);
		}

		void HandleOnERSDKReady ()
		{
			Debug.Log("ERSDK Gesture File Set... Ready");
			ERSdkManager.OnReady -= HandleOnERSDKReady;
			ExerciseView.OnFinish += HandleOnExerciseFinish;
			AddFramePanelViewEvents ();
		}

		void HandleOnExerciseFinish (int count, float duration)
		{
			RemoveFramePanelVeiwEvents ();
			ExerciseView.OnFinish -= HandleOnExerciseFinish;

			DataController.OnUpdated += HandleOnExerciseDataUpdated;
			DataController.Instance.UpdateExerciseData (count, duration);
		}

		void HandleOnExerciseDataUpdated ()
		{
			DataController.OnUpdated -= HandleOnExerciseDataUpdated;
			nextState = typeof(RS_Summary);
			GoNext ();
		}	

		/// <summary>
		/// 		/// </summary>
		public void AddFramePanelViewEvents()
		{
			FramePanelView.OnGoHome += HandleOnGoHome;
			FramePanelView.OnGoUserInfo += HandleOnGoUserInfo;
			FramePanelView.OnAppExit += HandleOnAppExit;
		}

		public void RemoveFramePanelVeiwEvents()
		{
			FramePanelView.OnGoHome -= HandleOnGoHome;
			FramePanelView.OnGoUserInfo -= HandleOnGoUserInfo;
			FramePanelView.OnAppExit -= HandleOnAppExit;			
		}

		void HandleOnAppExit ()
		{
			ExerciseView.OnFinish -= HandleOnExerciseFinish;
			RemoveFramePanelVeiwEvents ();
		}

		void HandleOnGoUserInfo ()
		{
			ExerciseView.OnFinish -= HandleOnExerciseFinish;
			RemoveFramePanelVeiwEvents ();

			nextState = typeof(RS_Register);
			GoNext ();
		}

		void HandleOnGoHome ()
		{
			ExerciseView.OnFinish -= HandleOnExerciseFinish;
			RemoveFramePanelVeiwEvents ();

			nextState = typeof(RS_Home);
			GoNext ();
		}	
		//////////
	}

}

