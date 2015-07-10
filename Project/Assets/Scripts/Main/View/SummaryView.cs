using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using com.erik.training.model;
using com.erik.training.controller;


namespace com.erik.training.view{

	public class SummaryView : MonoBehaviour {

		public delegate void SummaryViewEventDelegate();
		public static event SummaryViewEventDelegate OnGOHome;

		public ExerciseStatusSubView resultSubview;
		public Text textEmailSendReport;
		public Button buttonHome;
		
		// Use this for initialization
		void Start () {
			buttonHome.onClick.AddListener (OnButtonHome);
			ShowExerciseResults ();
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		private void OnButtonHome()
		{
			Debug.Log("Button Home Click");
			if (OnGOHome != null)
				OnGOHome ();
		}

		void ShowExerciseResults()
		{
			ExerciseData exeData = DataController.Instance.GetData ();
			resultSubview.SetImage (exeData.image);
			resultSubview.SetDuration (exeData.duration);
			resultSubview.SetRepetition (exeData.repetition);
		}
	}

}
