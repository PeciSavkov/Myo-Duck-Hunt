using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour {

	public float bulletForce = 760f;

	void Update()
	{
		Destroy (gameObject);
	}
	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.tag == "Duck") {
			DuckMovement.DuckAlive = false;
			Destroy (gameObject);
		}
	}
}
