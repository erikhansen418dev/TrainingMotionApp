using UnityEngine;
using System.Collections;

namespace com.erik.training.model{

	[System.Serializable]
	public class ExerciseData {
		
		public string gestureFilePath;
		public string StartPosImagePath;
		public string EndPosImagePath;

		private int repetition = 0;
		private float duration = 0;
		
		public ExerciseData()
		{
			
		}
		
		public ExerciseData (string _gestureFileName)
		{	
			gestureFilePath = _gestureFileName;
		}	

		public ExerciseData (ExerciseData data)
		{
			gestureFilePath = data.gestureFilePath;
			StartPosImagePath = data.StartPosImagePath;
			EndPosImagePath = data.EndPosImagePath;

			repetition = data.repetition;
			duration = data.duration;
		}

		public string ToString()
		{
			string exerciseData = string.Format ("GestureFilePath : {0}, StartPosImagePath : {1}, EndPosImagePath : {2}, Repetition : {3}, Duration : {4}",
			                                     gestureFilePath, StartPosImagePath, EndPosImagePath, repetition, duration);  
			return exerciseData;
		}
	}

}

