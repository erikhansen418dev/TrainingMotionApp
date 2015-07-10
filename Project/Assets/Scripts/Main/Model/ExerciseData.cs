using UnityEngine;
using System.Collections;

namespace com.erik.training.model{

	[System.Serializable]
	public class ExerciseData {

		public string title;
		public string description;
		public string gestureFilePath;
		public Sprite image;
//		public string StartPosImagePath;
//		public string EndPosImagePath;

		public int repetition = 0;
		public float duration = 0;
		
		public ExerciseData()
		{
			
		}
		
		public ExerciseData (string _gestureFileName)
		{	
			gestureFilePath = _gestureFileName;
		}	

		public ExerciseData (ExerciseData data)
		{
			title = data.title;
			description = data.description;
			gestureFilePath = data.gestureFilePath;
			image = data.image;
//			StartPosImagePath = data.StartPosImagePath;
//			EndPosImagePath = data.EndPosImagePath;

			repetition = data.repetition;
			duration = data.duration;

		}

		public void IncreaeRepetion ()
		{
			repetition ++;
		}

		public string ToString()
		{
			string exerciseData = string.Format ("Title : {0}, Description : {1}, GestureFileName : {2}, ImageName : {3}, Repetition : {4}, Duration : {5}",
			                                     title, description, gestureFilePath, image.name, repetition, duration);  
			return exerciseData;
		}

		public void Init()
		{

			repetition = 0;
			duration = 0f;
		}

	}

}

