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

	public float minRadius = .2f; 
	public float maxRadius = .1f;
	private float gravRadius; 

	private float radiusChangeSpeed = .2f; 

	//Selected color 
	private Color planCol; 
	private bool selectedCol = false; 

	void Start(){
		//Game Controller is an object that should be found in every game scene!!!
		gameController = GameObject.Find ("GameController").GetComponent<Selection>();

		highlight = Instantiate (gravityVisual);

		child = transform.GetChild (0);
		gravityEffector = child.gameObject.GetComponent<PointEffector2D> ();
		circleSize = child.gameObject.GetComponent<CircleCollider2D> ();

		highlight.transform.parent = transform; 
		highlight.GetComponent<SpriteRenderer> ().sprite = gravitySprite;
		highlight.transform.position = transform.position; 
		highlight.transform.localScale = new Vector3 (2f*circleSize.radius, 2f*circleSize.radius, 1f);
		highlight.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0.1f);

		planCol = gameObject.GetComponent<SpriteRenderer> ().color; 
	}

	public void planetSelected(){
		gameController.setSelectedId (gameObject.name);
		this.selected = true; 
	}

	public void deselect(){
		this.selected = false; 
	}

	void Update(){
		if(selected){
			gravRadius = circleSize.radius; 

			//Effect always showing ? :D
			if(!selectedCol){
				gameObject.GetComponent<SpriteRenderer> ().color = planCol + new Color(-.5f, -.5f, -.5f);
				selectedCol = true; 
			}
			if(Input.GetAxis("Mouse ScrollWheel") > 0f){
				if(circleSize.radius < maxRadius){
					circleSize.radius += radiusChangeSpeed; 
					
					highlight.transform.localScale += new Vector3 (2*radiusChangeSpeed, 2*radiusChangeSpeed, 0f);
				}
			}
			else if(Input.GetAxis("Mouse ScrollWheel") < 0f){
				if(circleSize.radius > minRadius){
					circleSize.radius -= radiusChangeSpeed; 

					highlight.transform.localScale += new Vector3 (-2*radiusChangeSpeed, -2*radiusChangeSpeed, 0f);
				}
			}
		}else{
			gameObject.GetComponent<SpriteRenderer> ().color = planCol; 
			selectedCol = false; 
		}
	}
}
