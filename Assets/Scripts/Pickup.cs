using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
	[SerializeField] GameObject pickupPrefab = null;


	private void OnTriggerEnter(Collider other) {
		if (other.TryGetComponent(out Player player)) {
			player.AddPoints(10);
			Instantiate(pickupPrefab, transform.position, Quaternion.identity);

			Destroy(gameObject);
		}

	}
}
