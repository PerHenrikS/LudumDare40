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

	public void planetSelected(){
		gameController.setSelectedId (gameObject.name);
		this.selected = true; 
	}

	public void deselect(){
		this.selected = false; 
	}
}
