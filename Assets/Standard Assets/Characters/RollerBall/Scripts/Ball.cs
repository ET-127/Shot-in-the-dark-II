using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

	private Rigidbody m_Rigidbody;
	private RaycastHit hit;
	public float rayLength;
	public LayerMask floorMask;

	[SerializeField] private float m_MaxVelociy = 1;
	[SerializeField] private float m_Acceleration = 1;
	[SerializeField] private float m_Decceleration = 1;

	private void Start()
	{
		m_Rigidbody = GetComponent<Rigidbody>();
		floorMask = LayerMask.GetMask ("Floor");

	}


	public void Move(Vector3 moveDirection)
	{
		float vel;
		float f;
		float i;

		i = moveDirection.normalized.magnitude;
		vel = m_Rigidbody.velocity.magnitude;
		f = m_Rigidbody.mass * (i * (m_MaxVelociy - vel) / Time.fixedDeltaTime);

		if (i == 1) {

			m_Rigidbody.AddForce (moveDirection * f);

		} else {

			m_Rigidbody.AddForce (-m_Rigidbody.velocity.normalized * m_Decceleration);

		}

	}

	public void Look (){

		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast (ray, out hit,rayLength)) {

			Vector3 playerToMouse = hit.point - transform.position;
			playerToMouse.y = 0f;

			Debug.Log (playerToMouse);
			Quaternion newRot = Quaternion.LookRotation(playerToMouse);
			m_Rigidbody.MoveRotation (newRot);

		}


	}

	public void Fire(){


	}

}