using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class Ball : MonoBehaviour
    {

        [SerializeField] private float m_MaxVelociy = 1;
		[SerializeField] private float m_Acceleration = 1;
		[SerializeField] private float m_Decceleration = 1;


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

			if (i == 1) {

				m_Rigidbody.AddForce (moveDirection * f);

			} else {

				m_Rigidbody.AddForce (-m_Rigidbody.velocity.normalized * m_Decceleration);

			}
           
        }

		public void Look (){

			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			var mousePosition = new Vector3(ray.origin.x, transform.position.y, ray.origin.z);

			Debug.Log (mousePosition);
			transform.LookAt(mousePosition);

    	}
	}
}