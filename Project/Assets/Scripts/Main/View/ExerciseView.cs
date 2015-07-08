using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using com.erik.training.model;
using com.erik.training.controller;

namespace com.erik.training.view
{
	public class ExerciseView : MonoBehaviour {
		
		public delegate void ExerciseEventDelegate();
		public static event ExerciseEventDelegate OnFinish;	

		public ExerciseStatusSubView statusSubview;
		public Button buttonFinish;

		private ExerciseData exeData;
		
		// Use this for initialization
		void Start () {

			buttonFinish.onClick.AddListener (OnButtonFinish);
			Init ();
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		private void Init ()
		{
			exeData = DataController.Instance.GetData ();
			Debug.Log (exeData.image.name);
			statusSubview.SetImage (exeData.image);
		}
		
		public void OnButtonFinish()
		{
			if (OnFinish != null)
				OnFinish ();
		}
		
		public void Show()
		{
			gameObject.SetActive (true);
		}
		
		public void Hide()
		{
			gameObject.SetActive (false);			
		}
	}


}
