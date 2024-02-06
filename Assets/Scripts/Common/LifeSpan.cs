using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpan : MonoBehaviour {

    [SerializeField] private float lifeSpan;

    void Start() {
        Destroy(gameObject, lifeSpan);
    }
}
