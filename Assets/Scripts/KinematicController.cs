using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicController : MonoBehaviour {
	[SerializeField][Range(0f, 40f)] float speed = 1f;
	[SerializeField] float maxDistance = 5;
	[SerializeField] float turnangle = 20;
	[SerializeField] float turnSpeed = 10;


	private void Update() {


        Vector3 direction = Vector3.zero;
		direction.x = Input.GetAxis("Horizontal");
		direction.y = Input.GetAxis("Vertical");

		Vector3 force = direction * speed * Time.deltaTime;
		transform.Translate(force);

		transform.localPosition = Vector3.ClampMagnitude(transform.localPosition, maxDistance);
		Quaternion qyaw = Quaternion.AngleAxis(direction.x * turnangle, Vector3.up);
		Quaternion qpitch = Quaternion.AngleAxis(direction.y * -turnangle, Vector3.right);

		Quaternion rotation = qyaw * qpitch;

		transform.localRotation = Quaternion.Slerp(transform.localRotation, rotation, Time.deltaTime * turnSpeed);
	}

}
