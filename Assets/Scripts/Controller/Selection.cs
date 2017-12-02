using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour {

	public bool launched = false; 

	//A class to control selections.
	private string selectedId = "HomePlanet"; 

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
}
