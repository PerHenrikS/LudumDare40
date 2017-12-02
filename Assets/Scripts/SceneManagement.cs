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
		int next = curr + 1; 
		SceneManager.LoadScene (next);
	}

	public void previousScene(){
		int curr = SceneManager.GetActiveScene ().buildIndex; 
		int previous = curr - 1; 
		SceneManager.LoadScene (previous);
	}
}
