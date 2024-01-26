using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoints : MonoBehaviour {
	[SerializeField] GameObject pickupPrefab = null;
	[SerializeField] GameManager gameManager = null;
	[SerializeField] int points = 10;
	bool nothit = true;


	private void OnTriggerEnter(Collider other) {
		if (nothit && other.TryGetComponent(out Player player)) {
			player.AddPoints(points);
			Instantiate(pickupPrefab, transform.position, Quaternion.identity);
			nothit = false;
			gameManager.pickupSound.Play();
		}

	}
}
