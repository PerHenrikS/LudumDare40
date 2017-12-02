using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePlanet : MonoBehaviour {

	public float rotationSpeed = 5f; 

	private Selection gameController; 
	private bool selected = false;

	void Start(){
		//Game Controller is an object that should be found in every game scene!!!
		gameController = GameObject.Find ("GameController").GetComponent<Selection>();
	}

	void OnMouseDown(){
		gameController.setSelectedId (gameObject.name);

		Debug.Log (gameController.getSelectedId ());
		if(selected){
			Debug.Log ("LAUNCH"); 
		}
		selected = true; 
	}

	public void deselect(){
		this.selected = false; 
	}

	void FixedUpdate(){
		
		//transform.Rotate (Vector3.forward * Time.deltaTime * rotationSpeed);
	}
}
