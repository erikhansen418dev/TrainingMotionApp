using UnityEngine;
using System.Collections;

public class CS_Loading : MonoBehaviour {

	#region PUBLIC VARIABLES

	public string strPathLoadingImage;
	public string strNameNextScene;

	#endregion  // PUBLIC VARIABLES


	#region PRIVATE VARIABLES

	private Texture2D textureLoadingImage;
	private AsyncOperation asyncLoading;
	private bool isLoading;

	#endregion PRIVATE VARIABLES


	#region // MOMOBEHAVIOR FUNCTIONS

	void Awake()
	{
		textureLoadingImage = Resources.Load<Texture2D>(strPathLoadingImage);
	}

	// Use this for initialization
	void Start () {

		if (textureLoadingImage == null) {			
			Debug.Log("Loading Screen Error : Loading Image was not Loaded from Resources. Please check path of the Loading Image");
			return;
		}

		if (string.IsNullOrEmpty (strNameNextScene)) {
			Debug.Log("Loading Screen Error : Name Of the Scene to be loaded was not set. Please check NameNextScene");
			return;

		}

		DontDestroyOnLoad (this);
		Application.backgroundLoadingPriority = ThreadPriority.Low;
		isLoading = true;
		asyncLoading = Application.LoadLevelAsync (strNameNextScene);

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("Loding image drawing...");
		if (asyncLoading.isDone) {
			StartCoroutine(NewSceneAfterDelay(1));
//			isLoading = false;
		}
		else {
//			isLoading = true;	
		}
	}

	void OnGUI()
	{
		if (isLoading) {
			Debug.Log("Loding image drawing...");
			GUI.DrawTexture (new Rect (0f, 0f, Screen.width, Screen.height), textureLoadingImage, ScaleMode.StretchToFill); 
		}
	}


	IEnumerator NewSceneAfterDelay(float delaySec)
	{
		yield return new WaitForSeconds (delaySec);
		isLoading = false;
		Destroy (this.gameObject);
	}

	#endregion // MONOBEHAVIOR FUNCTIONS


	#region MEMBER METHODS



	#endregion // MEMBER METHODS

}
