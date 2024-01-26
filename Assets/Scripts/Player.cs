using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] TMP_Text score_Text;
	[SerializeField] FloatVariable health;
	[SerializeField] PhysicsCharacterController characterController;
	[Header("Events")]
	[SerializeField] IntEvent scoreEvent;
	[SerializeField] VoidEvent StartGameEvent;
	[SerializeField] VoidEvent playerDeadEvent;

	public void OnRespawn(GameObject respawn) {
		transform.position = respawn.transform.position;
		transform.rotation = respawn.transform.rotation;
		characterController.Reset();
	}
	private void Start() {
		health.value = 5.5f;
		characterController.enabled = false;
	}

	private void OnEnable() {
		StartGameEvent.Subscribe(OnStartGame);
	}

	[SerializeField]private IntVariable score;
	
	public int Score { 
		get { return score.value; } 
		private set { score.value = value; 
			score_Text.text = "Score: " + score.value; 
			scoreEvent.RaiseEvent(score.value); 
		} 
	}

	public void AddPoints(int points) {
		Score += points;
	}

	private void OnStartGame() {
		characterController.enabled = true;
	}

	public void Damage(float damage) {
		health.value -= damage;
		if (health.value <= 0) {
			playerDeadEvent.RaiseEvent();
		}
	}
}
