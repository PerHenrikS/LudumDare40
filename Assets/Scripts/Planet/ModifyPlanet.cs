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

	private GameObject highlight; 

	public GameObject gravityVisual; 
	public Sprite gravitySprite; 

	public float minRadius = 5f; 
	public float maxRadius = 20f;
	private float gravRadius; 

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
		if(highlight){
			Destroy (highlight);
		}
		this.selected = false; 
	}

	void Update(){
		if(selected){
			gravRadius = circleSize.radius; 
			if(!effectShowing){
				effectShowing = true; 
			 	highlight = Instantiate (gravityVisual);
				highlight.transform.parent = transform; 
				highlight.GetComponent<SpriteRenderer> ().sprite = gravitySprite;
				highlight.transform.position = transform.position; 
				highlight.transform.localScale = new Vector3 (2f*circleSize.radius, 2f*circleSize.radius, 1f);
				highlight.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0.1f);
			}
			if(Input.GetAxis("Mouse ScrollWheel") > 0f){
				Debug.Log ("Radius: " + circleSize.radius);
				circleSize.radius += .1f; 
				highlight.transform.localScale += new Vector3 (.2f, .2f, 0f);
			}
			else if(Input.GetAxis("Mouse ScrollWheel") < 0f){
				circleSize.radius -= .1f; 
				highlight.transform.localScale += new Vector3 (-.2f, -.2f, 0f);
			}
		}
	}
}
