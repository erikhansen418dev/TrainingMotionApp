using UnityEngine;
using UnityEngine.UI;
using System.Collections;


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
	}

}
