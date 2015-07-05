﻿using UnityEngine;
using System.Collections;
using com.erik.util;
using com.erik.training.model;


namespace com.erik.training.controller{

	public class DataController : Singleton<DataController> {

		public delegate void DataControllerEventDelegate();
		public static event DataControllerEventDelegate OnUpdated;

		private ExerciseData curData;

		protected override void Init ()
		{
			base.Init ();
		}
		// Use this for initialization
		void Start () {
			
		}

		public void SetData(ExerciseData data)
		{
			curData = new ExerciseData (data);
			Debug.Log (" DataController: GetData : " + GetData ().ToString ());

			if (OnUpdated != null)
				OnUpdated ();
		}

		public ExerciseData GetData()
		{
			return curData;
		}
		

	}

}

