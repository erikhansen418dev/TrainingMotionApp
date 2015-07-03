using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace com.erik.training.view{

	public class HomeView : MonoBehaviour {

		public delegate void HomeViewEventDelegate (int index);
		public static event HomeViewEventDelegate OnEnterExercise;

		public List<ExerciseEntry> listExerciseEntries;
		
		// Use this for initialization
		void Start () {

			int index = 0;
			foreach (ExerciseEntry e_entry in listExerciseEntries) {
			
				e_entry.OnEntrySelected += HandleOnEntrySelected;
				e_entry.SetIndex(index);
				index ++;
			}
			
		}

		void HandleOnEntrySelected (int index)
		{
			Debug.Log ("HandleOnEntrySelected.. : " + index);

			foreach (ExerciseEntry e_entry in listExerciseEntries) {
				
				e_entry.OnEntrySelected -= HandleOnEntrySelected;
			}

			if (OnEnterExercise != null)
				OnEnterExercise (index);
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}

} 


