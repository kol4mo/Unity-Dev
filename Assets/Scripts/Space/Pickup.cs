using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour {
	[SerializeField] GameObject pickupPrefab;

	private void OnTriggerEnter(Collider other) {

		if (other.gameObject.TryGetComponent(out PlayeShip player)) {
			action(player);
			if (pickupPrefab != null) Instantiate(pickupPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

	protected abstract void action(PlayeShip player);
}
