using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class PlayeShip : MonoBehaviour, IDamagable {
	[SerializeField] private PathFollower PathFollower;
	[SerializeField] Action action;
	[SerializeField] private IntEvent ScoreEvent;
	[SerializeField] private Inventory inventory;
	[SerializeField] private IntVariable score;


	[SerializeField] protected GameObject hitPrefab;
	[SerializeField] protected GameObject destroyPrefab;
	[SerializeField] protected float maxhp;
	[SerializeField] protected float speed;
	public float Health = 100;


	private void Start() {
		ScoreEvent.Subscribe(AddPoint);

	}

	private void Update() {
		if (Input.GetButtonDown("Fire1")) {
			inventory.Use();
		}
		if (Input.GetButtonUp("Fire1")) {
			inventory.StopUse();
		}

		PathFollower.speed = speed * ((Input.GetKey(KeyCode.Space)) ? 2 : 1);
			
	}

	public void AddPoint(int points) {
		score.value += points;
		Debug.Log(score.value);
	}

	public void ApplyDamage(float damage) {
		Health -= damage;
		if (Health < 0) {
			if (destroyPrefab != null) {
				Instantiate(destroyPrefab, gameObject.transform.position, Quaternion.identity);
			}
			Destroy(gameObject);
		} else {
			if (hitPrefab != null) {
				Instantiate(hitPrefab, gameObject.transform.position, Quaternion.identity);
			}
		}
	}

	public void ApplyHealth(float health) {
		this.Health += health;
		this.Health = Mathf.Min(this.Health, maxhp);
	}
}
