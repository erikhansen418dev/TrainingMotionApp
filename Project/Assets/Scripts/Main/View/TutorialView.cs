using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using com.erik.training.model;

namespace com.erik.training.view{

	public class TutorialView : MonoBehaviour {
		public delegate void TutorialViewEventDelegate();
		public static event TutorialViewEventDelegate OnPresentationCompleted;

		private float timeCount = 3.0f;

		// Use this for initialization
		void Start () {

			StartCoroutine("Timer");
			
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

