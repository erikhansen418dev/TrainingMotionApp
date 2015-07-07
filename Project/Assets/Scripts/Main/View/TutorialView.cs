using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using com.erik.training.model;

namespace com.erik.training.view{

	public class TutorialView : MonoBehaviour {
		public delegate void TutorialViewEventDelegate();
		public static event TutorialViewEventDelegate OnPresentationCompleted;

		private float timeCount = 5.0f;

		public CircleTimer cirlceTimer;

		// Use this for initialization
		void Start () {

			StartCoroutine("Timer");
			cirlceTimer.StartCountTime (timeCount);
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		IEnumerator Timer()
		{
			yield return new WaitForSeconds (timeCount);

			if (OnPresentationCompleted != null)
				OnPresentationCompleted ();
		}
	}


}

