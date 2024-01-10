using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField][Range(-360, 360)] float rate;
    // Start is called before the first frame update

    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(rate * Time.deltaTime, Vector3.up);
    }
}
