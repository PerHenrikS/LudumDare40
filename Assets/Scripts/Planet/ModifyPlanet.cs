using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyPlanet : MonoBehaviour {

	private Selection gameController; 
	private bool selected = false; 
	private Transform child; 
	private PointEffector2D gravityEffector; 
	private CircleCollider2D circleSize; 

	private bool effectShowing = false; 

	public GameObject gravityVisual; 
	public Sprite gravitySprite; 

	void Start(){
		//Game Controller is an object that should be found in every game scene!!!
		gameController = GameObject.Find ("GameController").GetComponent<Selection>();

		child = transform.GetChild (0);
		gravityEffector = child.gameObject.GetComponent<PointEffector2D> ();
		circleSize = child.gameObject.GetComponent<CircleCollider2D> ();
	}

	public void planetSelected(){
		gameController.setSelectedId (gameObject.name);
		this.selected = true; 
	}

	public void deselect(){
		this.effectShowing = false; 
		this.selected = false; 
	}

	void Update(){
		if(selected){
			if(!effectShowing){
				effectShowing = true; 
				Transform highlight = Instantiate (gravityVisual.transform);
				highlight.parent = transform; 
				highlight.GetComponent<SpriteRenderer> ().sprite = gravitySprite;
				highlight.transform.position = transform.position; 
				highlight.transform.localScale = new Vector3 (circleSize.radius, circleSize.radius, 1f);
				highlight.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0.5f);
			}
			if(Input.GetAxis("Mouse ScrollWheel") > 0f){
				gravityEffector.forceMagnitude += .5f; 
			}
			else if(Input.GetAxis("Mouse ScrollWheel") < 0f){
				gravityEffector.forceMagnitude -= .5f; 
			}
		}
	}
}
