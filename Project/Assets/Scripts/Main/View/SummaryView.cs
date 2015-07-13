﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using com.erik.training.model;
using com.erik.training.controller;

using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;


namespace com.erik.training.view{

	public class SummaryView : MonoBehaviour {

		public delegate void SummaryViewEventDelegate();
		public static event SummaryViewEventDelegate OnGOHome;

		public ExerciseStatusSubView resultSubview;
		public Text textEmailSendReport;
		public Button buttonHome;
		
		// Use this for initialization
		void Start () {
			buttonHome.onClick.AddListener (OnButtonHome);
			ShowExerciseResults ();
			StartCoroutine("SendEmail");
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		private void OnButtonHome()
		{
			Debug.Log("Button Home Click");
			if (OnGOHome != null)
				OnGOHome ();
		}

		void ShowExerciseResults()
		{
			ExerciseData exeData = DataController.Instance.GetData ();
			resultSubview.SetImage (exeData.image);
			resultSubview.SetDuration (exeData.duration);
			resultSubview.SetRepetition (exeData.repetition);
		}

		IEnumerator SendEmail()
		{

			Debug.Log("Sending Email...");

			string path = "Exercise Result.xml";
			string emailAddrTo = UserData.user.email;
			string status;
			
			ExerciseResult exeResult = new ExerciseResult (UserData.user, DataController.Instance.GetData ());
			exeResult.Save (path);
			
/*			MailMessage mail = new MailMessage();
			
			mail.From = new MailAddress("rangeofmotion.xtr3d@gmail.com");
			mail.To.Add(emailAddrTo);
			mail.Subject = "Range of Motion app - Do not reply ";
			mail.Body = "Test";
			mail.Attachments.Add(new Attachment(path));
			
			SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
			smtpServer.Port = 587;
			smtpServer.Credentials = new System.Net.NetworkCredential("rangeofmotion.xtr3d@gmail.com", "rangeofmotionxtr3d") as ICredentialsByHost;
			smtpServer.EnableSsl = true;
			ServicePointManager.ServerCertificateValidationCallback = 
				delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
			{
				return true; 
			};
			smtpServer.Send(mail);
			status = "ok";
			
			Debug.Log("Sent..");			
			
*/
			yield return null;
			
		}
	}

}
