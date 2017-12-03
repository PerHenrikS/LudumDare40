using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour {

	//If i want to restrict cam movement all together on some scene
	public bool moveable = true; 

	public float moveSpeed = .5f; 
	public float zoomSpeed = 1f;

	public GameObject gameController; 
	private Selection selector; 

	void Start(){
		selector = gameController.GetComponent<Selection> ();
	}

	// Update is called once per frame
	void Update () {
		if(selector.getSelectedId() == ""){
			if(Input.GetAxis("Mouse ScrollWheel") < 0f){
				Camera.main.orthographicSize += zoomSpeed; 
			}
			if(Input.GetAxis("Mouse ScrollWheel") > 0f){
				Camera.main.orthographicSize -= zoomSpeed; 
			}
		}
		if(moveable){
			if(Input.GetKey("w")){
				transform.Translate (0f, moveSpeed, 0f);
			}
			if(Input.GetKey("a")){
				transform.Translate (-moveSpeed, 0f, 0f);
			}
			if(Input.GetKey("d")){
				transform.Translate (moveSpeed, 0f, 0f);
			}
			if(Input.GetKey("s")){
				transform.Translate (0f, -moveSpeed, 0f);
			}
		}
	}
}
