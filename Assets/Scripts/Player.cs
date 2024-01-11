using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] TMP_Text score_Text;


	private int score = 0;
	[SerializeField] private float Health = 100;
	
	public int Score { 
		get { return score; } 
		private set { score = value; score_Text.text = "Score: " + score; } }

	public void AddPoints(int points) {
		Score += points;
	}

}
