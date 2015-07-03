using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace com.erik.training.view{

	public class FramePanelView : MonoBehaviour {
		
		public Text textScreenTitle;
		public Text textUserInfo;
		public Button buttonClose;
		public GameObject cameraFeed;
		
		// Use this for initialization
		void Start () {
			
			buttonClose.onClick.AddListener (OnClose);	
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		
		private void OnClose()
		{
			Debug.Log(" FramePanelView : Close Button Clicked ");
			
		}
		
		public void SetTitle(string strTitle)
		{
			textScreenTitle.text = strTitle;
		}
		
		public void SetUserInfo(string strInfo)
		{
			textUserInfo.text = strInfo;
		}

		public void ActivateCameraFeed(bool bActivate)
		{
			cameraFeed.SetActive (bActivate);
		}
	}


}
