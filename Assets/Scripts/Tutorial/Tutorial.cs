using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {
	//Super hacky disgusting tutorial ahead ! 

	private bool homeClick = false; 
	private int tutState = 0; 

	private float originalY; 

	//Public visuals 
	public GameObject arrow; 
	public GameObject hint; 
	public GameObject tut1;
	public GameObject tut2; 
	public GameObject tut3; 
	public GameObject tut4; 

	public float floatStrength; 
	public float floatSpeed; 

	private bool changeOrigY = true;

	void Start()
	{
		this.originalY = arrow.transform.position.y;
		tutState = 1; 
	}

	void Update(){
		if(Input.GetMouseButton(0)){
			if(tutState == 4){
				tutState = 5; 
			}
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
			if(hit){
				if(hit.transform.name == "HomePlanet" && tutState == 3){
					tutState = 4; 
				}
				if(hit.transform.tag == "Selectable" && tutState == 1){
					tutState = 2; 
				}
			}
		}

		if(tutState == 2){
			if(Input.GetAxis("Mouse ScrollWheel") < 0f){
				tutState = 3; 
			}
		}

		arrow.transform.position = new Vector3(arrow.transform.position.x,
			originalY + ((float)Mathf.Sin(Time.time * floatSpeed) * floatStrength),
			arrow.transform.position.z);	
	

		switch(tutState){
		case 1: 
			break; 
		case 2: 
			Debug.Log ("Tutorial 2");
			tut1.SetActive (false);
			tut2.SetActive (true); 
			break; 
		case 3: 
			tut2.SetActive (false); 
			tut3.SetActive (true); 
			if (changeOrigY) {
				changeOrigY = false; 
				Vector3 tutpos = GameObject.Find ("Tut3Pos").transform.position;
				originalY = tutpos.y; 
				arrow.transform.position = new Vector3 (tutpos.x, originalY, tutpos.z);
				arrow.gameObject.SetActive (true);
			}
			break; 
		case 4: 
			tut3.SetActive (false); 
			tut4.SetActive (true);
			hint.SetActive (true); 
			arrow.gameObject.SetActive (false); 
			break; 
		case 5: 
			tut4.SetActive (false); 
			hint.SetActive (false); 
			break; 
		}
	}
}
