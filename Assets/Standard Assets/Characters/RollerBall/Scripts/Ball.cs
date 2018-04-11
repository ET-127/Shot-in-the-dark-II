using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class Ball : MonoBehaviour
    {

        [SerializeField] private float m_MovePower = 5; // The force added to the ball to move it.
        [SerializeField] private bool m_UseTorque = true; // Whether or not to use torque to move the ball.
        [SerializeField] private float m_MaxVelociy = 1;
		[SerializeField] private float m_Acceleration = 1;
		[SerializeField] private float m_Decceleration = 1;


        private const float k_GroundRayLength = 1f; // The length of the ray to check if the ball is grounded.
        private Rigidbody m_Rigidbody;
		private RaycastHit hit;

        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();

        }


        public void Move(Vector3 moveDirection)
        {
			float vel;
			float f;
			float i;

			i = moveDirection.normalized.magnitude;
			vel = m_Rigidbody.velocity.magnitude;
			f = m_Rigidbody.mass * (i * (m_MaxVelociy - vel) / Time.fixedDeltaTime);

			//Debug.Log (moveDirection.normalized);

			if (i == 1) {

				m_Rigidbody.AddForce (moveDirection * f);

			} else {

				m_Rigidbody.AddForce (-m_Rigidbody.velocity.normalized * m_Decceleration);

			}
           
        }

		public void Look (){

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit)) {
				Transform objectHit = hit.transform;

				// Do something with the object that was hit by the raycast.
				transform.LookAt(objectHit.position);

		}
    }
}
}