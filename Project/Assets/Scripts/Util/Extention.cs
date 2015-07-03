using UnityEngine;
using System.Collections;

namespace com.erik.util{

	public  static class Extention{

		public static T GetSafeComponent<T> (this GameObject obj) where T: MonoBehaviour
		{
			T component = obj.GetComponent<T> ();
			
			if (component == null) {
				Debug.LogError("Excepted to find of type " 
				               + typeof(T) + " but found none", obj);
			}
			
			return component;
		}
	}
}


	

