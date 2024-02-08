using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupex : MonoBehaviour {
	[SerializeField] GameObject pickupPrefab = null;
	[SerializeField] int points = 10;


	private void OnTriggerEnter(Collider other) {
		if (other.TryGetComponent(out Player player)) {
			player.AddPoints(points);
			Instantiate(pickupPrefab, transform.position, Quaternion.identity);

			Destroy(gameObject);
		}

	}
}
