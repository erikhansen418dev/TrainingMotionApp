using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace com.erik.training.view{

	public class ExerciseEntry : MonoBehaviour {

		public delegate void ExerciseEntryEventDelegate(int index);
		public event ExerciseEntryEventDelegate OnEntrySelected;

		private int entryIndex;
		public Button buttonExcercise;
		public Text textDescription;

		// Use this for initialization
		void Start () {
			buttonExcercise.onClick.AddListener (OnButtonExercise);
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		private void OnButtonExercise()
		{
			Debug.Log ("OnButtonExercise  : " + entryIndex);
			if (OnEntrySelected != null)
				OnEntrySelected (entryIndex);
		}

		public void SetIndex (int index)
		{
			entryIndex = index;
		}


	}
}
