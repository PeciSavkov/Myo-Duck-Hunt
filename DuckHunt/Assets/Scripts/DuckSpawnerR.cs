using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawnerR : MonoBehaviour {
	
	public GameObject Duck;
	public Transform spawnPoint;

	void FixedUpdate ()
	{
		if (DuckMovement.OnScreen == false && DuckMovement.SpawnedFromR == false ) {
			BulletSpawner.BulletCount = 3;
			DuckMovement.DuckAlive = true;
			DuckMovement.OnScreen = true;
			DuckMovement.MovingRight = false;
			DuckMovement.SpawnedFromR = true;
			Instantiate (Duck, new Vector3(spawnPoint.position.x, Random.Range( -3f , 4f), -2), spawnPoint.rotation);
		}
	}
}
