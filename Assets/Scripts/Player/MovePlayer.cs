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

	public void launchPod(){
		gameObject.GetComponent<Rigidbody2D> ().AddRelativeForce (Vector3.up * launchForce * launchMultiplier);
		homePlanet.deselect ();
	}
}
