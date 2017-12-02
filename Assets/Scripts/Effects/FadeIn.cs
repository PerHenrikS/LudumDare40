using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class FadeIn : MonoBehaviour {

	public float fadeInTime = 1f; 

	//Script to gradually show victory panel
	void fadeIn(){
		Image alphaChannel = GetComponent<Image> ();
		alphaChannel.CrossFadeAlpha (10f, fadeInTime, true); 
	}
}
