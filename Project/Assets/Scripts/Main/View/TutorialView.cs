using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using com.erik.training.model;

namespace com.erik.training.view{

	public class TutorialView : MonoBehaviour {
		public delegate void TutorialViewEventDelegate();
		public static event TutorialViewEventDelegate OnPresentationCompleted;

		private float timeCount = 5.0f;

		public CircleTimer circleTimer;

		// Use this for initialization
		void Start () {	

			circleTimer.OnTimerEnd += HandleOnTimerEnd;
			circleTimer.StartCountTime (timeCount);
			
		}

		void HandleOnTimerEnd ()
		{
			circleTimer.OnTimerEnd -= HandleOnTimerEnd;

			if (OnPresentationCompleted != null)
				OnPresentationCompleted ();
		}	
		
		// Update is called once per frame
		void Update () {
			
		}
	}


}

