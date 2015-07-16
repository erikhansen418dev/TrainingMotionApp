using UnityEngine;
using System.Collections;

namespace com.erik.training.model{

	public class Settings {	

		public static string smtpClient 	 = "smtp.gmail.com";
		public static string senderEmailAddr = "rangeofmotion.xtr3d@gmail.com";
		public static string password		 = "rangeofmotionxtr3d";

		public static string gestureFolderPath 		= System.IO.Path.Combine(Application.streamingAssetsPath , "Gestures");
		public static string gifAnimationFolderPath = System.IO.Path.Combine(Application.streamingAssetsPath , "Gif Animations");
	}
}

