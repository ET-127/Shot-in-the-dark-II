using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed;
	Rigidbody rb;

	void Start(){

		rb = GetComponent<Rigidbody> ();

	}

	public void SetSpeed(float newSpeed){

		speed = newSpeed;

	}

	void Update () {

		rb.velocity = transform.forward * speed;
		
	}
}
