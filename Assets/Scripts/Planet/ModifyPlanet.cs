using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyPlanet : MonoBehaviour {

	private Selection gameController; 
	private bool selected = false; 

	void Start(){
		//Game Controller is an object that should be found in every game scene!!!
		gameController = GameObject.Find ("GameController").GetComponent<Selection>();
	}

	/*
	void OnMouseDown(){
		selected = true;
		gameController.setSelectedId (gameObject.name); 

		Debug.Log (gameController.getSelectedId());
	}
	*/

	public void deselect(){
		this.selected = false; 
	}
}
