using UnityEngine;
using System.Collections;

public class PickupParticlesDestruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// destroy "pickup particles" after 5 seconds
		Destroy (gameObject, 5f);
	}
}
