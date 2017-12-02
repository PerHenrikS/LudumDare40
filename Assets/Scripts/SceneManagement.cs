using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; 

public class SceneManagement : MonoBehaviour {

	//Change scene based on scene name
	public void changeScene(string scene){
		SceneManager.LoadScene (scene);
	}

	public void restartCurrent(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void nextScene(){
		int curr = SceneManager.GetActiveScene ().buildIndex;
		Debug.Log ("Current scene: "+ curr); 
		int next = curr + 1; 
		Debug.Log ("Next scene: " + next);
		SceneManager.LoadScene (next);
	}
}
