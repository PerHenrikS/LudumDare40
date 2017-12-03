using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetFloat : MonoBehaviour {
	//Script will be attached to the planet which is going to float 

	private float originalPos; 
	public float floatSpeed = 2f; 
	public float floatStrength = 2f; 

	void Start () {
		originalPos = transform.position.y; 
	}

	void Update(){
		transform.localPosition = new Vector3(transform.position.x,
			originalPos + ((float)Mathf.Sin(Time.time * floatSpeed) * floatStrength),
			transform.position.z);
	}
}
