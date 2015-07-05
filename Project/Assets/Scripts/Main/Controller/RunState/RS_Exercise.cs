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
			ExerciseView.OnFinish += HandleOnExerciseFinish;

		}

		void HandleOnExerciseFinish ()
		{
			ExerciseView.OnFinish -= HandleOnExerciseFinish;
			nextState = typeof(RS_Summary);
			GoNext ();

		}
		

	}

}

