using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

	public Transform target;
	public Vector3 offset;

	public float smoothSpeed = 0.125f;
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 desiredPos = target.position + offset;

		transform.position = desiredPos;	


	}
}
