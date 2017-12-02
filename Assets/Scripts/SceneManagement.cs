using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; 

public class SceneManagement : MonoBehaviour {

	//Change scene based on scene name
	public void changeScene(string scene){
		SceneManager.LoadScene (scene);
	}
}
