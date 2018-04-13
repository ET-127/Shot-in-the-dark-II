using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallUserControl : MonoBehaviour
{
	private Ball ball; // Reference to the ball controller.

	private Vector3 move;
	// the world-relative desired move direction, calculated from the camForward and user input.

	private Transform cam; // A reference to the main camera in the scenes transform
	private Vector3 camForward; // The current forward direction of the camera


	private void Awake()
	{
		// Set up the reference.
		ball = GetComponent<Ball>();


		// get the transform of the main camera
		if (Camera.main != null)
		{
			cam = Camera.main.transform;
		}
		else
		{
			Debug.LogWarning(
				"Warning: no main camera found. Ball needs a Camera tagged \"MainCamera\", for camera-relative controls.");
			// we use world-relative controls in this case, which may not be what the user wants, but hey, we warned them!
		}
	}


	private void Update()
	{
		// Get the axis and jump input.

		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		// calculate move direction
		// we use world-relative directions in the case of no main camera
		move = (v*Vector3.forward + h*Vector3.right).normalized;

	}


	private void FixedUpdate()
	{
		// Call the Move function of the ball controller
		ball.Move(move);
		ball.Look ();
		ball.Fire ();

	}
}