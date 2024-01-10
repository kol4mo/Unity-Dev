using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour {

    [SerializeField] Transform target = null;
    [SerializeField][Range(20, 90)] float defaultPitch = 40;
    [SerializeField] float distance = 5;
    [SerializeField] float sensitivity = 0.5f;

    float yaw = 0;
    float pitch = 0;

	private void Awake() {
        pitch = defaultPitch;
	}

	private void Update() {
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch += Input.GetAxis("Mouse Y") * sensitivity;
        Quaternion qyaw = Quaternion.AngleAxis(yaw, Vector3.up);
        Quaternion qpitch = Quaternion.AngleAxis(pitch, Vector3.right);
        Quaternion rotation = qyaw * qpitch;
        transform.position = target.transform.position + (rotation * Vector3.back * distance);
        transform.rotation = rotation;
    }
}
