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
	private float launchForce = 10.0f; 
	private bool launchReady = true; 
	private bool preparing = false; 

	public float prepareTime = 1f; 

	void Start(){
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
			if (!charging) {
				Vector3 targetScreenPos = Camera.main.WorldToScreenPoint (target.position);
				targetScreenPos.z = 0;
				Vector3 targetToMouseDir = Input.mousePosition - targetScreenPos;
				Vector3 targetToMe = transform.position - target.position;
				targetToMe.z = 0;
				Vector3 newTargetToMe = Vector3.RotateTowards (targetToMe, targetToMouseDir, 2f, 0f);
				transform.position = target.position + radius * newTargetToMe.normalized;
			}
			if(launchReady){
				if(Input.GetMouseButtonDown(0)){ 
					clickedTime = Time.time;
					charging = true; 
				}
				if(Input.GetMouseButtonUp(0) && charging){
					launchForce = launchForce + Time.time - clickedTime; 

					gameObject.GetComponent<Rigidbody2D> ().AddRelativeForce (Vector3.up * launchForce * 100f);
					homePlanet.deselect ();
					launchForce = 1f; 
					charging = false;
					gameController.launchCubesat ();
					Debug.Log ("Launched!");
				}
			}
		}
	}

	public void prepareToLaunch(){
		StartCoroutine (prepareLaunch ());
	}

	IEnumerator prepareLaunch(){
		Debug.Log ("Preparing for launch");
		yield return new WaitForSeconds (prepareTime);
		launchReady = true; 
		Debug.Log ("Launch Ready"); 
	}
}
