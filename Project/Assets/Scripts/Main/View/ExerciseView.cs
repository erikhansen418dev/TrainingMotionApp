using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using com.erik.training.model;
using com.erik.training.controller;

using Xtr3D.Net.ColorImage;
using Xtr3D.Net.ExtremeMotion;
using Xtr3D.Net.ExtremeMotion.Data;
using Xtr3D.Net.ExtremeMotion.Gesture;

namespace com.erik.training.view
{
	public class ExerciseView : MonoBehaviour {
		
		public delegate void ExerciseEventDelegate(int count, float duration);
		public static event ExerciseEventDelegate OnFinish;	
		
		public ExerciseStatusSubView statusSubview;
		public Button buttonFinish;

		public Text textRepetition;
		public Text textDuration;
		
		private ExerciseData exeData;

		private int count = 0;
		private float totalTime = 0;
		
		
		private bool strokeCompleted = true;
		private bool inStroke = false;
		
		// Use this for initialization
		void Start () {

			ExtremeMotionEventsManager.MyGesturesFrameReadyHandler += MyGestureFrameReadyEventHandler;

			buttonFinish.onClick.AddListener (OnButtonFinish);
			Init ();
		}

		private void MyGestureFrameReadyEventHandler(object sender, GesturesFrameReadyEventArgs e)
		{
			
			// Opening the received frame
			using (var gesturesFrame = e.OpenFrame() as GesturesFrame)
			{
				
				if (gesturesFrame != null) 
				{
					BaseGesture[] gestures = gesturesFrame.FirstSkeletonGestures();
					foreach (BaseGesture gesture in gestures)
					{
						Debug.Log("GestureID : " + gesture.ID);
						
						switch(gesture.ID)
						{
						case 1:
							inStroke = true;
							break;
						case 2:
							if(inStroke)
							{
								inStroke = false;
								OnOneStrokeCompeted();
							}
							break;
						default:
							break;
							
						}
					}
				}   
				
			}
		}

		
		// Update is called once per frame
		void Update () {

			textRepetition.text = count.ToString();
			
			totalTime += Time.deltaTime;
			int seconds = ((int)totalTime) % 60;
			int minutes = ((int)totalTime) / 60;
			string time = minutes + ":" + seconds;
			
			textDuration.text = time;
		}

		void OnOneStrokeCompeted()
		{
			count++;
			Debug.Log ("OnOneStrokeCompeted  : " + count);
		}


		void OnApplicationPause(bool paused) 
		{
			if (paused) {
				ExtremeMotionEventsManager.MyGesturesFrameReadyHandler -= MyGestureFrameReadyEventHandler;
			}
			else 
			{
				ExtremeMotionEventsManager.MyGesturesFrameReadyHandler += MyGestureFrameReadyEventHandler;
			}
		}
		
		private void Init ()
		{
			exeData = DataController.Instance.GetData ();
			Debug.Log (exeData.image.name);
			statusSubview.SetImage (exeData.image);
		}
		
		public void OnButtonFinish()
		{
			if (OnFinish != null)
				OnFinish (count, totalTime);
		}
		
		public void Show()
		{
			gameObject.SetActive (true);
		}
		
		public void Hide()
		{
			gameObject.SetActive (false);			
		}
	}
	
	
}










/*using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using com.erik.training.model;
using com.erik.training.controller;

namespace com.erik.training.view
{
	public class ExerciseView : MonoBehaviour {
		
		public delegate void ExerciseEventDelegate(int count, float duration);
		public static event ExerciseEventDelegate OnFinish;	

		public ExerciseStatusSubView statusSubview;
		public Button buttonFinish;

		private ExerciseData exeData;
		
		// Use this for initialization
		void Start () {

			buttonFinish.onClick.AddListener (OnButtonFinish);
			Init ();
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		private void Init ()
		{
			exeData = DataController.Instance.GetData ();
			Debug.Log (exeData.image.name);
			statusSubview.SetImage (exeData.image);
		}
		
		public void OnButtonFinish()
		{
			if (OnFinish != null)
				OnFinish ();
		}
		
		public void Show()
		{
			gameObject.SetActive (true);
		}
		
		public void Hide()
		{
			gameObject.SetActive (false);			
		}
	}


}
*/