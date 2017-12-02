using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePlanet : MonoBehaviour {

	public float rotationSpeed = 5f; 

	private Selection gameController; 
	private MovePlayer playerScript; 

	private bool selected = true;

	void Start(){
		//Game Controller is an object that should be found in every game scene!!!
		gameController = GameObject.Find ("GameController").GetComponent<Selection>();
		playerScript = GameObject.Find ("Cubesat").GetComponent<MovePlayer> ();
	}

	void OnMouseDown(){
		gameController.setSelectedId (gameObject.name);

		Debug.Log (gameController.getSelectedId ());
		selected = true; 
		playerScript.prepareToLaunch ();
	}

	public bool isSelected(){
		return this.selected;
	}

	public void deselect(){
		this.selected = false; 
	}
}
