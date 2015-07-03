using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CalibrationView : MonoBehaviour {

	public delegate void CalibrationViewEventDelegate();
	public static CalibrationViewEventDelegate OnGoHome;

	public Button buttonGoHome;

	// Use this for initialization
	void Start () {

		buttonGoHome.onClick.AddListener (OnButtonGoHome);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnButtonGoHome()
	{
		if (OnGoHome != null)
			OnGoHome ();
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
