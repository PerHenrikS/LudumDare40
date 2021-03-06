﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour {
	//Have to do object selection with raycasting because of 2 colliders on the planets

	public bool launched = false; 

	private bool win = false; 

	public GameObject endScreen; 
	//A class to control selections.
	private string selectedId = ""; 

	//Setter for selectedId
	public void setSelectedId(string id){
		//Deselect current if it exists
		if(GameObject.Find(selectedId)){
			GameObject.Find (selectedId).SendMessage ("deselect");
		}
		this.selectedId = id; 
	}

	//Getter for selectedID
	public string getSelectedId(){
		return selectedId; 
	}

	public void launchCubesat(){
		this.launched = true;
	}

	void Update(){
		if(Input.GetMouseButton(0)){
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
			if(hit){
				if(hit.transform.tag == "Selectable"){
					hit.collider.SendMessage ("planetSelected");
				}
				if(hit.transform.name == "HomePlanet"){
					hit.collider.SendMessage ("launchPod");
				}
			}else{
				if(selectedId != "HomePlanet"){
					this.setSelectedId ("");
				}				
			}
		}
	}

	void planetReached(){
		this.win = true; 
		endScreen.SetActive (true);
		endScreen.transform.GetChild (0).GetComponent<FadeIn> ().SendMessage ("fadeIn");
	}

	public bool getWin(){
		return this.win;
	}
}
