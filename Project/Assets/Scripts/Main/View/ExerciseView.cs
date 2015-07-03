using UnityEngine;
using System.Collections;

public class ExerciseView : MonoBehaviour {

	public delegate void ExerciseEventDelegate();
	public static event ExerciseEventDelegate OnFinish;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
