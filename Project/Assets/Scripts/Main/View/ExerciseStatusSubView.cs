using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using com.erik.training.controller;


namespace com.erik.training.view
{
	public class ExerciseStatusSubView : MonoBehaviour {
		
		public Image imageStartPos;
		public Image imageEndPos;
		public Text  textRepetitions;
		public Text  textDuration;
				
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public void SetImage(Sprite sprite)
		{
			imageStartPos.sprite = sprite;
		}
	}

}
