using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace com.erik.training.view{

	public class CircleTimer : MonoBehaviour {

		public Image thinCircle;
		public Image ThickCircle;
		public Image ball;	

		private const float pi = 3.141592654f;
		private float ball_R = 43.0f;
		private float timeCount = 0f;
		private float timer = 0f;
		private bool isCounting = false;
		private float angleRad = 0f;
		
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			if (timer >= timeCount) {
				isCounting = false;
				Init();
			}

			if (! isCounting)
				return;

			timer += Time.deltaTime;
			angleRad = 2* pi * timer / timeCount;

			SetBallPos (angleRad);
			ThickCircle.fillAmount = timer / timeCount;			
		}

		public void StartCountTime(float time)
		{
			isCounting = true;
			timeCount = time;
		}

		private void SetBallPos(float angle)
		{
			ball.rectTransform.localPosition = new Vector3(ball_R * Mathf.Sin(angle), ball_R * Mathf.Cos(angle));
		}

		private void Init()
		{

			timer = 0f;

			ThickCircle.type = Image.Type.Filled;
			ThickCircle.fillMethod = Image.FillMethod.Radial360;
			ThickCircle.fillOrigin = 0;

			SetBallPos (0.0f);
		}


	}

}
