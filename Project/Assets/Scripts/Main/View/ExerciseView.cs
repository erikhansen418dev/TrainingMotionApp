using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace com.erik.training.view
{
	public class ExerciseView : MonoBehaviour {
		
		public delegate void ExerciseEventDelegate();
		public static event ExerciseEventDelegate OnFinish;
		
		public ExerciseStatusSubView statusSubview;
		public Button buttonFinish;
		
		// Use this for initialization
		void Start () {

			buttonFinish.onClick.AddListener (OnButtonFinish);
		}
		
		// Update is called once per frame
		void Update () {
			
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
