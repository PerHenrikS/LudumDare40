using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

	private bool charging = false; 
	private bool selected = true; 
	//target = Home Planet
	public Transform target; 
	public float radius = 4f; 
	private Selection gameController; 
	private HomePlanet homePlanet;

	//Launch variables
	private float clickedTime = 0f; 
	private float launchForce = 1.0f; 
	private bool launchReady = true;  
	public float launchMultiplier = 10f; 	//Multiplier for launch force to get a nicer feeling

	public float prepareTime = 1f; 

	private AudioSource audioSource; 

	void Start(){
		audioSource = transform.gameObject.GetComponent<AudioSource> ();
		gameController = GameObject.Find ("GameController").GetComponent<Selection>();
		homePlanet = GameObject.Find ("HomePlanet").GetComponent<HomePlanet> ();

		target = GameObject.Find ("HomePlanet").transform; 
	}

	void Update(){
		selected = homePlanet.isSelected ();
		if(!selected){
			launchReady = false; 
		}

		if(selected && !gameController.launched){
			if(launchReady){
				if(Input.GetMouseButtonDown(0)){ 
					clickedTime = Time.time;
					charging = true; 
				}
				if(Input.GetMouseButtonUp(0) && charging){
					gameObject.GetComponent<Rigidbody2D> ().AddRelativeForce (Vector3.up * launchForce * launchMultiplier);
					homePlanet.deselect (); 
					charging = false;
					gameController.launchCubesat ();
					audioSource.Play();
				}
			}
		}
	}

	public void prepareToLaunch(){
		StartCoroutine (prepareLaunch ());
	}

	//Check if collided planet is target
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "TargetPlanet"){
			gameController.SendMessage ("planetReached");
		}
	}

	IEnumerator prepareLaunch(){
		charging = false; 
		yield return new WaitForSeconds (prepareTime);
		launchReady = true; 
	}
}
