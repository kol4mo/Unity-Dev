using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;

public class PathFollower : MonoBehaviour {
    [SerializeField] SplineContainer spline;
    [SerializeField][Range(0, 40)] public float speed = 1;

    float tdistance = 0;

    //public float speed { get; set; }
    public float length { get { return spline.CalculateLength(); } }
    public float distance {
        get { return tdistance * length; }
        set {tdistance = value / length; }
    }



	// Update is called once per frame
	void Update()
    {
        distance += speed * Time.deltaTime;
        UpdateTransform(math.frac(tdistance));
    }

    void UpdateTransform(float t) {
        Vector3 position = spline.EvaluatePosition(t);
        Vector3 up = spline.EvaluateUpVector(t);
        Vector3 forward = Vector3.Normalize(spline.EvaluateTangent(t));
        Vector3 right = Vector3.Cross(up, forward);

        transform.position = position;
        transform.rotation = Quaternion.LookRotation(forward, up);
    }
}
