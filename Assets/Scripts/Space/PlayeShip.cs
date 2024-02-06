using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class PlayeShip : Interactable {
	[SerializeField] Action action;
	[SerializeField] private Inventory inventory;
	public float health = 100;

	public override void OnInteractActive(GameObject gameObject) {
	}

	public override void OnInteractEnd(GameObject gameObject) {
	}

	public override void OnInteractStart(GameObject gameObject) {
	}

	private void Start() {
		if (action != null) {
			action.onEnter += OnInteractStart;
			action.onStay += OnInteractActive;
		}
	}

	private void Update() {
		if (Input.GetButtonDown("Fire1")) {
			inventory.Use();
		}
		if (Input.GetButtonUp("Fire1")) {
			inventory.StopUse();
		}
	}
}
