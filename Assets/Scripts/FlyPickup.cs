﻿using UnityEngine;
using System.Collections;

public class FlyPickup : MonoBehaviour {

	[SerializeField]
	private GameObject pickupPrefab;

	void OnTriggerEnter(Collider other) {

		// if the collider other is tagged with 'player'...
		if (other.CompareTag ("Player")) {

			// ...add the pickup particles...
			Instantiate(pickupPrefab, transform.position, Quaternion.identity);

			// decrement total number of flies
			FlySpawner.totalFlies--;

			//update the counter
			ScoreCounter.score++;

			Destroy (gameObject);

		}
	}
}