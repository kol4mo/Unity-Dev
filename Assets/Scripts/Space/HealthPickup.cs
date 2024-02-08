using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup {
	[SerializeField]float health;

	protected override void action(PlayeShip player) {
		player.ApplyHealth(health);
	}
}
